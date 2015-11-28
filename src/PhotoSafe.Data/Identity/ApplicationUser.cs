using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Safe> SafesCreated { get; set; }

        public ICollection<Safe> SafesAdministrated { get; set; }
    }
}
