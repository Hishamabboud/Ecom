using Ecommerence.Domain.Interfaces.Repositories;
using Ecommerence.Domain.Models;
using Ecommerence.Repository.Contexts;
using Ecommerence.Repository.Repositories.Common;

namespace Ecommerence.Repository.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(MainDbContext context) : base(context)
        {
        }
    }
}
