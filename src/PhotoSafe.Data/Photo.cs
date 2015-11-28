using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data
{
    public class Photo
    {
        public int Id { get; set; }

        public string Captions { get; set; }

        public int DepositId { get; set; }

        [ForeignKey("DepositId")]
        [InverseProperty("Photos")]
        public Deposit Safe { get; set; }
    }
}
