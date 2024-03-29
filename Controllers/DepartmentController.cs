using Lap3_2.Models;
using Microsoft.AspNetCore.Mvc;
using Lap3_2.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Lap3_2.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext db = new ITIContext();
        IDeptRepo db;
        public DepartmentController(IDeptRepo _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var model= db.GetAll();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dp)
        {
            if(dp.DeptId != 0 && dp.DeptName?.Length>2)
            {
                db.Add(dp);
                return RedirectToAction("index");
            }
            return View(dp);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = db.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Department dept , int? id)
        {
            var old = db.GetById(id.Value);
            db.Update(dept);
            return RedirectToAction("index");
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
                return BadRequest();
            var model = db.GetById(id.Value);   
            if(model == null)
                return NotFound();
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = db.GetById(id.Value);
            if (model == null)
                return NotFound();
            db.Delete(id.Value);
            return RedirectToAction("index");
        }
    }
}
