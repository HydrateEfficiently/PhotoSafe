using PhotoSafe.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data
{
    public class SafeFollower
    {
        public int Id { get; set; }

        public int SafeId { get; set; }

        public string FollowerId { get; set; }

        [ForeignKey("SafeId")]
        public virtual Safe Safe { get; set; }

        [ForeignKey("FollowerId")]
        public virtual ApplicationUser Follower { get; set; }
    }
}
