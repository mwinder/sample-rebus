using System;
using Infrastructure;
using Rebus;
using Rebus.Configuration;
using Messages;

namespace Subscriber
{
    class Program
    {
        static void Main()
        {
            using (var adapter = new BuiltinContainerAdapter())
            {
                adapter.Register(() => new CustomerSubscriptions());

                var bus = Configure.With(adapter)
                    .Serialization(s => s.UseJsonSerializer())
                    .Transport(t => t.UseMsmqWithQueue(typeof(Program).FullName))
                    .MessageOwnership(d => d.FromRebusConfigurationSection())
                    .CreateBus()
                    .Start();

                bus.Subscribe<CustomerSubscribed>();

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }

        public class CustomerSubscriptions : IHandleMessages<CustomerSubscribed>
        {
            public void Handle(CustomerSubscribed message)
            {
                Console.WriteLine("Received {0}: {1}", message, message.Name);
            }
        }
    }
}
