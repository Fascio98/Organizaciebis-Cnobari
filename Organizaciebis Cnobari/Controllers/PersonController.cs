using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Organizaciebis_Cnobari.Data;
using Organizaciebis_Cnobari.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Organizaciebis_Cnobari.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PersonController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public async Task<IActionResult> PersonIndex(int pageNumber = 1)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(await PaginatedList<Person>.CreateAsync(_context.People, pageNumber, 6));
        }
        public async Task<IActionResult> AddNewPerson()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewPerson([Bind("Id,Name,LastName,Gender,PersonalID,BirthDay,City,TelephoneNumbers,ImageFile")] Person model)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string Extension = Path.GetExtension(model.ImageFile.FileName);
            model.Image = fileName = fileName + DateTime.Now.ToString("yymmssffff") + Extension;
            string path = Path.Combine(wwwRootPath + "/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            _context.People.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PersonIndex));
        }
        public async Task<IActionResult> EditPerson(int id)
        {
            var obj = _context.People.Where(x => x.Id == id).FirstOrDefault();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> EditPerson([Bind("Id,Name,LastName,Gender,PersonalID,BirthDay,City,TelephoneNumbers,ImageFile")] Person model)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.Name) ;
            string Extension = Path.GetExtension(model.ImageFile.Name);
            model.Image = fileName = fileName + DateTime.Now.ToString("yymmssffff") + Extension;
            string path = Path.Combine(wwwRootPath + "/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            _context.People.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(PersonIndex));
        }
        public IActionResult DeletePerson()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeletePerson(Person model)
        {          
            _context.People.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(PersonIndex));
        }
        public IActionResult PersonDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
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
