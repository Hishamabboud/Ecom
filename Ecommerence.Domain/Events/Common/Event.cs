using MediatR;
using System;

namespace Ecommerence.Domain.Events.Common
{
    public abstract class Event : Message, INotification
    {
        public DateTime DateTime { get; private set; }

        protected Event()
        {
            DateTime = DateTime.UtcNow;
        }
    }
}
