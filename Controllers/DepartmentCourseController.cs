using Lap3_2.Models;
using Lap3_2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lap3_2.Controllers
{
    public class DepartmentCourseController : Controller
    {
        ITIContext db = new ITIContext();
        IDeptRepo deptRepo;
        IStudentRepo studentRepo;
        ICourseRepo courseRepo;
        public DepartmentCourseController(IDeptRepo _deptRepo, IStudentRepo _studentRepo , ICourseRepo _courseRepo)
        {
            deptRepo = _deptRepo;
            studentRepo = _studentRepo;
            courseRepo = _courseRepo;

        }
        public IActionResult ShowCourses(int? id)
        {
            var model = deptRepo.GetById(id.Value);
            return View(model);
        }
        public IActionResult ManageCourses(int? id)
        {
            var model = deptRepo.GetById(id.Value);
            var allcourse = courseRepo.GetAll();
            var CoursesInDept = model.Courses;
            var CoursesNotInDept = allcourse.Except(CoursesInDept).ToList();
            ViewBag.CoursesNotInDept = CoursesNotInDept;
            return View(model);
        }

        [HttpPost]
        public IActionResult ManageCourses(int? id , List<int> CourseToRemove , List<int> CourseToAdd)
        {
            Department dept = deptRepo.GetById(id.Value);

            foreach (var item in CourseToRemove)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Remove(c);
            }
            foreach (var item in CourseToAdd)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Add(c);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
        public IActionResult AddStudentDegree(int deptid , int crsid)
        {
           // var student = db.Students.Where(a=>a.DeptNo == deptid).ToList();
            var dpt = db.Departments.Include(a=>a.Students).FirstOrDefault(a=>a.DeptId == deptid);
            var crs = db.Courses.FirstOrDefault(a=>a.Id == crsid);
            ViewBag.CrsId = crs;
            return View(dpt);
        }

        [HttpPost]
        public IActionResult AddStudentDegree(int deptid, int crsid , Dictionary<int,int> degree)
        {
            foreach (var item in degree)
            {
                var stdcrs = db.StudentCourse.FirstOrDefault(a => a.Student_Id == item.Key && a.Course_Id == crsid);
                if (stdcrs == null)
                {
                    StudentCourse studentCourse = new StudentCourse() { Student_Id = item.Key, Course_Id = crsid, Grade = item.Value };
                    db.StudentCourse.Add(studentCourse);
                }
                else
                {
                    stdcrs.Grade = item.Value;
                }
            }
            db.SaveChanges ();

            return RedirectToAction("Index", "Department");
        }
    }
}
