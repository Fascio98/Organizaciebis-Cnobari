using Microsoft.AspNetCore.Mvc;
using Organizaciebis_Cnobari.Data;
using Organizaciebis_Cnobari.Entities;
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
            var Organizations = _context.Organizations.ToList();
            return View(Organizations);
        }
        public IActionResult AddNewOrganization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewOrganization(Organization model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var obj = model;
            _context.Organizations.Add(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(OrganizationIndex));
        }
        public IActionResult EditOrganization()
        {
            return View();
        }
        [HttpPost]
       /* public IActionResult EditOrganization(Organization model)
        {
            var obj = _context.Organizations.Where(x => x.Id.Equals(model.Id));
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View(obj);
        }*/

        public IActionResult DeleteOrganization()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteOrganization(Organization model)
        {
            var obj = model;
            _context.Organizations.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(OrganizationIndex));
        }
    }
}
