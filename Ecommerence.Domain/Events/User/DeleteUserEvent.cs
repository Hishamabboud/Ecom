using Ecommerence.Domain.Events.Common;
using System;

namespace Ecommerence.Domain.Events.User
{
    public class DeleteUserEvent : Event
    {
        public DeleteUserEvent(Guid id)
        {
            Id = id;

            AggregateId = Id;
        }

        public Guid Id { get; private set; }
    }
}
