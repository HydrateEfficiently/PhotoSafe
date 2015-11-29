using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.ViewModels
{
    public class DepositViewModel
    {
        public string Caption { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }
    }
}
