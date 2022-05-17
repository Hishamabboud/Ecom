using Ecommerence.Domain.Commands.Common;
using System;

namespace Ecommerence.Domain.Commands.Product
{
    public class DeleteProductCommand : Command
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
