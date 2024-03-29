﻿using Ecommerence.Domain.Enums;
using Ecommerence.Domain.Events.Common;
using System;

namespace Ecommerence.Domain.Events.User
{
    public class UpdateUserEvent : Event
    {
        public UpdateUserEvent(Guid id, string name, string email, UserProfile profile)
        {
            Id = id;
            Name = name;
            Email = email;
            Profile = profile;

            AggregateId = Id;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public UserProfile Profile { get; set; }
    }
}
