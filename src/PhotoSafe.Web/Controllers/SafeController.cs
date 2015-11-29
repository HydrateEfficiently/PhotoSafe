using AutoMapper;
using Microsoft.AspNet.Mvc;
using PhotoSafe.Services;
using PhotoSafe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoSafe.Web.Controllers
{
    [Route("safe")]
    public class SafeController : Controller
    {
        private ISafeService _safeService;

        public SafeController(ISafeService safeService)
        {
            _safeService = safeService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(_safeService.GetSafes());
        }

        [Route("new")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("new")]
        [HttpPost]
        public async Task<IActionResult> Create(SafeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _safeService.CreateSafe(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [Route("details/{id}")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_safeService.GetSafe(id));
        }


    }
}
