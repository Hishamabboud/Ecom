using Ecommerence.Domain.Commands;
using Ecommerence.Domain.Commands.Common;
using Ecommerence.Domain.Enums;
using System;

namespace Ecommerence.Domain.Commands.User
{
    public class UpdateUserCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserProfile Profile { get; set; }
    }
}
