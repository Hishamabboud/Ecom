using Ecommerence.Domain.Commands.Common;
using System;

namespace Ecommerence.Domain.Commands.User
{
    public class DeleteUserCommand : Command
    {
        public DeleteUserCommand(Guid id) => this.Id = id;

        public Guid Id { get; set; }
    }
}
