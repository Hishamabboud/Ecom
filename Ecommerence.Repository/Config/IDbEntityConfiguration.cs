using Microsoft.EntityFrameworkCore;

namespace Ecommerence.Repository.Config
{
    public interface IDbEntityConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
