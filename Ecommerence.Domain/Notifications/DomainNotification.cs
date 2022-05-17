using Ecommerence.Domain.Events.Common;

namespace Ecommerence.Domain.Notifications
{
    public class DomainNotification : Event
    {
        public string Message { get; private set; }

        public DomainNotification(string message)
        {
            Message = message;
        }
    }
}
