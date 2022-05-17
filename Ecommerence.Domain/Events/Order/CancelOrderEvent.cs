using Ecommerence.Domain.Events.Common;
using System;

namespace Ecommerence.Domain.Events.Order
{
    public class CancelOrderEvent : Event
    {
        public CancelOrderEvent(Guid orderId, Guid userId)
        {
            OrderId = orderId;
            UserId = userId;

            AggregateId = orderId;
        }

        public Guid OrderId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
