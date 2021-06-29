using Microsoft.AspNetCore.Hosting;
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
        
        public async Task<IActionResult> PersonIndex(int pageNumber = 1)
        {
            return View(await Organizaciebis_Cnobari.Models.PaginatedList<Entities.Person>.CreateAsync(_context.People, pageNumber, 6));
        }
        public async Task<IActionResult> AddNewPerson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewPerson(Person model)
        {
            var obj = model;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.People.Add(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(PersonIndex));
        }
        public async Task<IActionResult> EditPerson(int id)
        {
            var obj = _context.People.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> EditPerson(Person model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ჩანაწერები ვერ განახლდა!";
                return View(model);
            }
            ViewBag.Message1 = "ჩანაწერები წარმატებით განახლდა!";
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().Id = model.Id;
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().Name = model.Name;
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().LastName = model.LastName;
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().Gender = model.Gender;
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().PersonalID = model.PersonalID;
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().BirthDay = model.BirthDay;
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().City = model.City;
            _context.People.Where(x => x.Id.Equals(model.Id)).FirstOrDefault().TelephoneNumbers = model.TelephoneNumbers;
            _context.SaveChanges();
            return View(model);
        }
        public IActionResult DeletePerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeletePerson(Person model)
        {
            var obj = model;
            _context.People.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(PersonIndex));
        }
        public IActionResult PersonDetails(int id)
        {
            var obj = _context.People.Find(id);           
            return View(obj);
        }
        /*
         <div class="col sm-10">
        <label asp-for="Image">ტელეფონის ნომრები</label>
        <div class="custom-file">
            <input asp-for="Image" class="custom-file-input" id="customFile" />
            <label class="custom-file-label" for="customFile">აირჩიე ფოტო</label>
        </div>
        <span class="text-danger" asp-validation-for="Image"></span>
        </div>
         */
    }
}
