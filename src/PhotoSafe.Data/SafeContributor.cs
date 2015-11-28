using PhotoSafe.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data
{
    public class SafeContributor
    {
        public int Id { get; set; }

        public int SafeId { get; set; }

        public string ContributorId { get; set; }

        [ForeignKey("SafeId")]
        public virtual Safe Safe { get; set; }

        [ForeignKey("ContributorId")]
        public virtual ApplicationUser Contributor { get; set; }
    }
}
