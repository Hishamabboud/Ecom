using MediatR;
using Ecommerence.API.Auth;
using Ecommerence.Domain.Bus;
using Ecommerence.Domain.Enums;
using Ecommerence.Domain.Notifications;
using System;
using System.Security.Claims;
using Ecommerence.Auth;
using Microsoft.AspNetCore.Http;

namespace Ecommerence.Controllers.Common
{
    [BaererAuthorize]
    public abstract class AuthenticatedController : BaseController
    {
        protected AuthenticatedController(IMediatorHandler mediator, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(mediator, bus, notifications)
        {

        }

        protected Guid UserId
        {
            get => Guid.Parse(this.GetClaim(ClaimTypes.NameIdentifier));
        }

        protected bool IsAdmin
        {
            get => this.GetClaim(ClaimTypes.Role) == UserProfile.Admin.ToString();
        }
    }
}
