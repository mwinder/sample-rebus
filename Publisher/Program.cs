using System;
using System.Transactions;
using Infrastructure;
using Messages;
using Rebus.Configuration;

namespace Publisher
{
    class Program
    {
        static void Main()
        {
            using (var adapter = new BuiltinContainerAdapter())
            {
                var bus = Configure.With(adapter)
                    .Serialization(s => s.UseJsonSerializer())
                    .Transport(t => t.UseMsmqWithQueue(typeof(Program).FullName))
                    .Subscriptions(s => s.StoreInXmlFile("subscriptions.xml"))
                    .CreateBus()
                    .Start();

                var customer = new Random();

                Console.WriteLine("Press enter to publish a message");
                while (Console.ReadLine().Length == 0)
                {
                    using (var tx = new TransactionScope())
                    {
                        // perform several calls to the queueing system in here
                        bus.Publish(new CustomerSubscribed(string.Format("Customer #{0}", customer.Next())));
                        //bus.Send(new CustomerSubscribed("Sending"));

                        tx.Complete();
                    }
                }
            }
        }
    }

    
}
