using Microsoft.AspNet.Mvc;
using PhotoSafe.Services;
using PhotoSafe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Web.Controllers
{
    [Route("safe/deposit")]
    public class DepositController : Controller
    {
        private readonly ISafeService _safeService;
        private readonly IDepositService _depositService;

        public DepositController(
            ISafeService safeService,
            IDepositService depositService)
        {
            _safeService = safeService;
            _depositService = depositService;
        }

        [Route("{depositId:int}")]
        [HttpGet]
        public async Task<IActionResult> Details(int depositId)
        {
            var deposit = await _depositService.Get(depositId);
            return View(deposit);
        }

        [Route("{safeId:int}/create")]
        [HttpGet]
        public IActionResult Create(int safeId)
        {
            var safe = _safeService.GetSafe(safeId);
            ViewData["safeId"] = safeId;
            return View();
        }

        [Route("{safeId}/create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepositViewModel model)
        {
            if (ModelState.IsValid)
            {
                int depositId = await _depositService.Create(model);
                return RedirectToAction(nameof(Details), new { depositId = depositId });
            }

            return View(model);
        }
    }
}
