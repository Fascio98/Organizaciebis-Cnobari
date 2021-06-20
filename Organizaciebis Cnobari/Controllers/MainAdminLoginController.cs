using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Organizaciebis_Cnobari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Controllers
{
    public class MainAdminLoginController : Controller
    {
        private readonly ILogger<MainAdminLoginController> _logger;

        public MainAdminLoginController(ILogger<MainAdminLoginController> logger)
        {
            _logger = logger;
        }
        public IActionResult MainAdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MainAdminLogin(MainAdmin model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return RedirectToAction("Index","Home");
        }
    }
}
