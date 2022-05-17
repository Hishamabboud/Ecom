using Microsoft.EntityFrameworkCore;
using Ecommerence.Repository.Config;
using Ecommerence.Repository.Mapping.Common;

namespace Ecommerence.Repository.Contexts
{
    public class EventStoreSQLContext : DbContext
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddAssemblyConfiguration<IEventMap>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
