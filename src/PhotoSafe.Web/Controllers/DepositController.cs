using Microsoft.AspNet.Mvc;
using PhotoSafe.Services;
using PhotoSafe.Web.ViewModels.Safe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Web.Controllers
{
    [Route("safe/deposit")]
    public class DepositController : Controller
    {

        private ISafeService _safeService;

        public DepositController(ISafeService safeService)
        {
            _safeService = safeService;
        }

        [Route("{safeId}/create")]
        [HttpGet]
        public IActionResult Create(int safeId)
        {
            var safe = _safeService.GetSafe(safeId);
            ViewData["safeId"] = safeId;
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(DepositViewModel model)
        {
            return View();
        }
    }
}
