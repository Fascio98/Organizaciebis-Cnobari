using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI;
using Organizaciebis_Cnobari.Data;
using Organizaciebis_Cnobari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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
        [ValidateAntiForgeryToken]
        public IActionResult MainAdminLogin(MainAdmin model)
        {           
            if (ModelState.IsValid)
            {
                var obj = _context.MainAdmin.Where(x => x.UserName.Equals(model.UserName) && x.Password.Equals(model.Password)).FirstOrDefault();
                if (obj!=null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
                return View(model);
            return RedirectToAction("Index","Home");
        }
    }
}
