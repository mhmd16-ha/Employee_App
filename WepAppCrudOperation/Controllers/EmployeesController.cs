using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using WepAppCrudOperation.Data;
using WepAppCrudOperation.Models;

namespace WepAppCrudOperation.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AplicationDbContext _context;

        public EmployeesController(AplicationDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.Include(x=> x.Department).OrderBy(x=>x.EmployeeName).ToList(); 
            return View(employees);
        }
        public IActionResult Create()

        {
            ViewBag.Departments = _context.Deoartments.OrderBy(x=>x.DepartmentName).ToList();   

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee model)

        {
            UploadImage(model);
            if (ModelState.IsValid)
            {
                _context.Employees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = _context.Deoartments.OrderBy(x => x.DepartmentName).ToList();

            return View();
        }

        private void UploadImage(Employee model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count > 0)
            {
                //uploade image
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream? fileStream = new FileStream(Path.Combine(@"wwwroot/", "Images", ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                model.ImageUser = ImageName;
            }
            else if (model.ImageUser == null && model.EmployeeID == null)
            {
                //not uploade image
                model.ImageUser = "DefaultImage.jpg";
            }
            else
            {

                model.ImageUser = model.ImageUser;
            }
        }

        public IActionResult Edit(int? id)

        {
            ViewBag.Departments = _context.Deoartments.OrderBy(x => x.DepartmentName).ToList();
            var result=_context.Employees.Find(id);
            return View("Create",result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Employee model)
        {
            UploadImage(model);
            if (ModelState.IsValid)
            {
                _context.Employees.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)

        {
            
            var result = _context.Employees.Find(id);
            if(result != null)
            {
                _context.Employees.Remove(result);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
    
}
