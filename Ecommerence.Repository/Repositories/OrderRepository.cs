using Ecommerence.Domain.Interfaces.Repositories;
using Ecommerence.Domain.Models;
using Ecommerence.Repository.Contexts;
using Ecommerence.Repository.Repositories.Common;

namespace Ecommerence.Repository.Repositories
{
    public class OrderRepository : CrudRepository<Order>, IOrderRepository
    {
        public OrderRepository(MainDbContext context) : base(context)
        {
        }
    }
}
