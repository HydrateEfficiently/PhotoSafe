using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.ViewModels
{
    public class CreateDepositViewModel
    {
        [Required]
        public int SafeId { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        public List<IFormFile> PhotoFormFiles { get; set; }
    }
}
