using Lap3_2.Models;
using Lap3_2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lap3_2.Controllers
{
    public class StudentController : Controller
    {
        IDeptRepo deptRepo;
        IStudentRepo studentRepo;
        public StudentController(IDeptRepo _deptRepo , IStudentRepo _studentRepo)
        {
            deptRepo = _deptRepo;
            studentRepo = _studentRepo;
        }
        public IActionResult Index()
        {
            var model = studentRepo.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.deptList = deptRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                studentRepo.Add(student);
                return RedirectToAction("Index");
            }
            ViewBag.deptList = deptRepo.GetAll();
            return View(student);
        }
     
        public IActionResult details(int? id)
        {
            var model = studentRepo.GetById(id.Value);
            return PartialView(model);
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var model = studentRepo.GetById(id.Value);
            if (model == null)
                return BadRequest();
            ViewBag.deptList = deptRepo.GetAll();
            return View(model); 
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            studentRepo.Update(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(!id.HasValue)
                return BadRequest();
            var model = studentRepo.GetById(id.Value);
            studentRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
        public IActionResult CheckEmail(string? email)
        {
            var model = studentRepo.GetEmail(email);
            if (model != null)
                return Json(false);
            else
                return Json(true);
        }
    }

}
