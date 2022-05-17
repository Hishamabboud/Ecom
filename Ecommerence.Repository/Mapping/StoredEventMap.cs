using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerence.Domain.Models;
using Ecommerence.Repository.Config;
using Ecommerence.Repository.Mapping.Common;

namespace Ecommerence.Repository.Mapping
{
    internal class StoredEventMap : DbEntityConfiguration<StoredEvent>, IEventMap
    {
        public override void Configure(EntityTypeBuilder<StoredEvent> entity)
        {
            entity.Property(c => c.Id).HasColumnName("Id");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
