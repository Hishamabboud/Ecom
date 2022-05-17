using Ecommerence.Domain.Events.Common;
using System;

namespace Ecommerence.Domain.Events.Product
{
    public class DeleteProductEvent : Event
    {
        public DeleteProductEvent(Guid id)
        {
            Id = id;

            AggregateId = Id;
        }

        public Guid Id { get; private set; }
    }
}
