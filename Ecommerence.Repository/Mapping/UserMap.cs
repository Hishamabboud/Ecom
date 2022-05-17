using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerence.Domain.Models;
using Ecommerence.Repository.Config;
using Ecommerence.Repository.Mapping.Common;

namespace Ecommerence.Repository.Mapping
{
    internal class UserMap : DbEntityConfiguration<User>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<User> entity)
        {
            entity.Property(c => c.Id).HasColumnName("Id");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
