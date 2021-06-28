using Microsoft.AspNetCore.Mvc;
using Organizaciebis_Cnobari.Data;
using Organizaciebis_Cnobari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly AppDbContext _context;
        public OrganizationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OrganizationIndex()
        {
            return View();
        }
        public IActionResult AddNewOrganization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewOrganization(Models.Organization model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("OrganizationIndex");
        }
    }
}
