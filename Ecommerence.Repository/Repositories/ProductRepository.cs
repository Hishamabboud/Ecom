using Ecommerence.Domain.Interfaces.Repositories;
using Ecommerence.Domain.Models;
using Ecommerence.Repository.Contexts;
using Ecommerence.Repository.Repositories.Common;

namespace Ecommerence.Repository.Repositories
{
    public class ProductRepository : CrudRepository<Product>, IProductRepository
    {
        public ProductRepository(MainDbContext context) : base(context)
        {
        }
    }
}
