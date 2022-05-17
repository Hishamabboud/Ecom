using Microsoft.AspNetCore.Authorization;
using Ecommerence.Domain.Enums;
using System.Linq;

namespace Ecommerence.Auth
{
    public class BaererAuthorizeAttribute : AuthorizeAttribute
    {
        public BaererAuthorizeAttribute() : base("Bearer")
        {
        }

        public BaererAuthorizeAttribute(params UserProfile[] profiles) : base("Bearer") => this.Roles = string.Join(",", profiles.Select(e => e.ToString()).ToArray());
    }
}
