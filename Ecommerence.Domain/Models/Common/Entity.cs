using System;

namespace Ecommerence.Domain.Models.Common
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }
}
