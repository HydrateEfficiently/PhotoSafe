using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.ViewModels
{
    public class SafeViewModel
    {
        [Display(Name = "Subject")]
        public string SubjectName { get; set; }
    }
}
