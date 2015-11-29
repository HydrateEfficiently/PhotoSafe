using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data
{
    public class Deposit
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public DateTime CreatedDate { get; set; }

        public int SafeId { get; set; }

        [ForeignKey("SafeId")]
        [InverseProperty("Deposits")]
        public virtual Safe Safe { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
