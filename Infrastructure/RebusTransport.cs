using Rebus.Configuration;
using Rebus.Transports.Msmq;

namespace Infrastructure
{
    public static class RebusTransport
    {
        public static void UseMsmqWithQueue(this RebusTransportConfigurer configurer, string queueName)
        {
            configurer.UseMsmq(queueName, queueName + "-error");
        }
    }
}
