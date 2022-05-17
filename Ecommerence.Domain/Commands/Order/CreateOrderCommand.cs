using Ecommerence.Domain.Commands.Common;
using System;

namespace Ecommerence.Domain.Commands.Order
{
    public class CreateOrderCommand : RequestCommand<Models.Order>
    {
        public Guid UserId { get; set; }
    }
}
