using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerence.Domain.Interfaces.Identity
{
    public interface IUser
    {
        string Id { get; }
        string Name { get; }
        string Email { get; }
    }
}
