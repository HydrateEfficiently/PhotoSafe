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

        public int DepositId { get; set; }

        [ForeignKey("DepositId")]
        [InverseProperty("Photos")]
        public virtual Deposit Deposit { get; set; }

        public string ImageUploadFileName { get; set; }

        public int ImageUploadId { get; set; }

        [ForeignKey("ImageUploadId")]
        public virtual ImageUpload ImageUpload { get; set; }
    }
}
