using Microsoft.AspNetCore.Mvc;
using Organizaciebis_Cnobari.Data;
using Organizaciebis_Cnobari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;
        public PersonController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult PersonIndex()
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
