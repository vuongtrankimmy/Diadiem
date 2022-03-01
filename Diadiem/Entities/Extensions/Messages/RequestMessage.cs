using NServiceBus;

namespace Entities.Extensions.Messages
{
    public class RequestMessage : IMessage
    {
        public string Message { get; set; }
    }
}
