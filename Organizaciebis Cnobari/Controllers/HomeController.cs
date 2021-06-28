using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Organizaciebis_Cnobari.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewPerson(Person model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        /*public IActionResult EditPerson(int id)
        {
            return View();

        }
        [HttpPost]
        public IActionResult EditPerson(Person model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ViewBag.Message = "ჩანაწერები განახლდა!";
            return View(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditOrganization(int id)
        {
            return View();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditOrganization(Organization model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ViewBag.Message = "ჩანაწერები განახლდა!";
            return View(model);
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
