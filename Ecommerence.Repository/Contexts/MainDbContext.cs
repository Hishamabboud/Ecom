using Microsoft.EntityFrameworkCore;
using Ecommerence.Repository.Config;
using Ecommerence.Repository.Mapping.Common;
using System.Reflection;

namespace Ecommerence.Repository.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddAssemblyConfiguration<IEntityMap>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
