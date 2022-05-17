using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ecommerence.Controllers.Common;
using Ecommerence.Domain.Bus;
using Ecommerence.Domain.Commands.User;
using Ecommerence.Domain.Interfaces.Repositories;
using Ecommerence.Domain.Notifications;
using System;
using System.Threading.Tasks;

namespace Ecommerence.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository userRepository;

        public UserController(IMediatorHandler mediator, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IUserRepository userRepository) : base(mediator, bus, notifications)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(userRepository.Query());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Response(await userRepository.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUserCommand command)
        {
            await bus.SendAsync(command);
            return Response();
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]UpdateUserCommand command)
        {
            await bus.SendAsync(command);
            return Response();
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangeUserPasswordCommand command)
        {
            await bus.SendAsync(command);
            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await bus.SendAsync(new DeleteUserCommand(id));
            return Response();
        }
    }
}
