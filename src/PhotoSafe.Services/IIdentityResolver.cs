using PhotoSafe.Data.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhotoSafe.Services
{
    public interface IIdentityResolver
    {
        ClaimsPrincipal Resolve();

        string GetUserName();

        string GetCurrentUserId();

        bool IsSignedIn();
    }
}
