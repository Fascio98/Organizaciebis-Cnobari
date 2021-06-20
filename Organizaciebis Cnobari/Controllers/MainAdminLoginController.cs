using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Organizaciebis_Cnobari.Data;
using Organizaciebis_Cnobari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Controllers
{
    public class MainAdminLoginController : Controller
    {
        
        private readonly AppDbContext _context;
        public MainAdminLoginController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult MainAdminLogin()
        {
            /*_context.MainAdmin.Add(new Entities.MainAdmin
            {
                UserName = "Nikoloz1998",
                Password = "Nikusha12"
            }
                ) ;
            _context.SaveChanges();*/
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
