using Newtonsoft.Json;
using Ecommerence.Domain.Events.Common;
using Ecommerence.Domain.Interfaces.Identity;
using Ecommerence.Domain.Interfaces.Repositories;
using Ecommerence.Domain.Models;
using Ecommerence.Repository.Contexts;
using Ecommerence.Repository.Repositories.Common;
using System.Threading.Tasks;

namespace Ecommerence.Repository.Repositories
{
    public class StoredEventRepository : CrudRepository<StoredEvent>, IStoredEventRepository
    {
        private readonly IUser user;

        public StoredEventRepository(EventStoreSQLContext context, IUser user) : base(context) => this.user = user;

        public async Task AddEventAsync<TEvent>(TEvent @event) where TEvent : Event
        {
            await AddAsync(new StoredEvent(@event, JsonConvert.SerializeObject(@event), user?.Name));
            await context.SaveChangesAsync();
        }
    }
}
