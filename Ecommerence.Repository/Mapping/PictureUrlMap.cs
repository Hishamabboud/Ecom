using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerence.Domain.Models;
using Ecommerence.Repository.Config;
using Ecommerence.Repository.Mapping.Common;

namespace Ecommerence.Repository.Mapping
{
    internal class PictureUrlMap : DbEntityConfiguration<PictureUrl>, IEntityMap
    {
        public override void Configure(EntityTypeBuilder<PictureUrl> entity)
        {
            entity.Property(c => c.Id).HasColumnName("Id");
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
