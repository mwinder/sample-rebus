using Rebus;
using Rebus.Messages;
using System;

namespace Infrastructure
{
    public class MessageSerializer : ISerializeMessages
    {
        public Message Deserialize(ReceivedTransportMessage transportMessage)
        {
            throw new NotImplementedException();
        }

        public TransportMessageToSend Serialize(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
