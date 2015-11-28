using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using PhotoSafe.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhotoSafe.Services
{
    public class IdentityResolver : IIdentityResolver
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManger;

        public IdentityResolver(
            IHttpContextAccessor contextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _contextAccessor = contextAccessor;
            _userManger = userManager;
        }

        public ClaimsPrincipal Resolve()
        {
            if (_contextAccessor == null || _contextAccessor.HttpContext == null)
            {
                return ClaimsPrincipal.Current;
            }

            return _contextAccessor.HttpContext.User;
        }

        public string GetCurrentUserId()
        {
            return Resolve()?.GetUserId();
        }

        public string GetUserName()
        {
            return Resolve()?.GetUserName();
        }

        public bool IsSignedIn()
        {
            var user = Resolve();
            return user != null && user.IsSignedIn();
        }
    }
}
