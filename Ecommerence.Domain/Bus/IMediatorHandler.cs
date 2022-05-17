using Ecommerence.Domain.Commands.Common;
using Ecommerence.Domain.Events.Common;
using System.Threading.Tasks;

namespace Ecommerence.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task SendAsync<T>(T command) where T : Command;
        Task<TResult> RequestAsync<TResult>(RequestCommand<TResult> command);
        Task InvokeAsync<T>(T @event) where T : Event;
        Task InvokeDomainNotificationAsync(string message);
    }
}
