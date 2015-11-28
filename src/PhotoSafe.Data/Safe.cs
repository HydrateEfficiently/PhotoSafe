using PhotoSafe.Data.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoSafe.Data
{
    public class Safe
    {
        public int Id { get; set; }

        public string CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        [InverseProperty("SafesCreated")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public string AdministratorId { get; set; }

        [ForeignKey("AdministratorId")]
        [InverseProperty("SafesAdministrated")]
        public virtual ApplicationUser Administrator { get; set; }

        [Required]
        public string SubjectName { get; set; }

        public ICollection<Deposit> Deposits { get; set; }

        //public IEnumerable<SafeContributor> Contributors { get; set; }

        //public IEnumerable<SafeFollower> Followers { get; set; }
    }
}
