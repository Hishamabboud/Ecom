using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ecommerence.Domain.Bus;
using Ecommerence.Domain.Notifications;



namespace Ecommerence.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler notifications;
        protected readonly IMediatorHandler mediator;
        protected readonly IMediatorHandler bus;

        protected BaseController(IMediatorHandler mediator, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            this.bus = bus;
            this.mediator = mediator;
            this.notifications = (DomainNotificationHandler)notifications;
        }

        protected IEnumerable<DomainNotification> Notifications => notifications.GetNotifications();

        protected bool IsValidOperation() => !notifications.HasNotifications();

        protected new IActionResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                if (result == null)
                    return Ok();

                return Ok(result);
            }

            return BadRequest(Notifications);
        }



        protected string GetClaim(string claimType) => Convert.ToString(from x in User.Claims where x.Type == claimType select new { x.Value }); 

    }
}

