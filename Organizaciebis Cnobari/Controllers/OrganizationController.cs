using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organizaciebis_Cnobari.Data;
using Organizaciebis_Cnobari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        
        public IActionResult EditOrganization(int id)
        {
            var obj = _context.Organizations.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public IActionResult EditOrganization(Organization model)
        {          
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ჩანაწერები ვერ განახლდა!";
                return View(model);
            }
            ViewBag.Message1 = "ჩანაწერები წარმატებით განახლდა!";
            _context.Organizations.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().Id = model.Id;
            _context.Organizations.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().Name = model.Name;
            _context.Organizations.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().Address = model.Address;
            _context.Organizations.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().Activity = model.Activity;
            _context.SaveChanges();
            return View(model);
        }
        
        public IActionResult DeleteOrganization()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteOrganization(Organization model)
        {
            var obj = model;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Organizations.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(OrganizationIndex));
        }
        

    }
}
