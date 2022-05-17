using Ecommerence.Domain.Events.Common;
using Ecommerence.Domain.Interfaces.Repositories.Common;
using Ecommerence.Domain.Models;
using System.Threading.Tasks;

namespace Ecommerence.Domain.Interfaces.Repositories
{
    public interface IStoredEventRepository : ICrudRepository<StoredEvent>
    {
        Task AddEventAsync<TEvent>(TEvent @event) where TEvent : Event;
    }
}
