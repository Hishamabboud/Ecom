using MediatR;
using Ecommerence.Domain.Bus;
using Ecommerence.Domain.Commands.Common;
using Ecommerence.Domain.Events.Common;
using Ecommerence.Domain.Interfaces.Repositories;
using Ecommerence.Domain.Notifications;
using System.Threading.Tasks;

namespace Ecommerence.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;
        private readonly IStoredEventRepository storedEventRepository;

        public InMemoryBus(IMediator mediator, IStoredEventRepository storedEventRepository)
        {
            this.mediator = mediator;
            this.storedEventRepository = storedEventRepository;
        }

        public async Task SendAsync<T>(T command) where T : Command => await mediator.Send(command);

        public async Task<TResult> RequestAsync<TResult>(RequestCommand<TResult> command) => await mediator.Send<TResult>(command);

        public Task InvokeAsync<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                storedEventRepository.AddEventAsync(@event);

            return mediator.Publish(@event);
        }

        public async Task InvokeDomainNotificationAsync(string message) => await mediator.Publish(new DomainNotification(message));
    }
}
