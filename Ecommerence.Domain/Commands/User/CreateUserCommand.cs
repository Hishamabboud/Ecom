using Ecommerence.Domain.Commands.Common;
using Ecommerence.Domain.Enums;

namespace Ecommerence.Domain.Commands.User
{
    public class CreateUserCommand : Command
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public UserProfile Profile { get; set; }
    }
}
