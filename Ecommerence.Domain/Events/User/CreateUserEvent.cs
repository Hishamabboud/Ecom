using Ecommerence.Domain.Enums;
using Ecommerence.Domain.Events.Common;
using System;

namespace Ecommerence.Domain.Events.User
{
    public class CreateUserEvent : Event
    {
        public CreateUserEvent(Guid id, string name, string email, string password, UserProfile profile)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Profile = profile;

            AggregateId = Id;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserProfile Profile { get; set; }
    }
}
