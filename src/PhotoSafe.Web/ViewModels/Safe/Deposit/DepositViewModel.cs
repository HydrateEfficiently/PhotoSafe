using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Web.ViewModels.Safe
{
    public class DepositViewModel
    {
        public string Caption { get; set; }

        public List<IFormFile> File { get; set; }
    }
}
