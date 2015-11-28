using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Data
{
    public abstract class FileUpload
    {
        public int Id { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public long Length { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }
    }
}
