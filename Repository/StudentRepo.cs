using Lap3_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Lap3_2.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public void Add(Student student);
        public void Update(Student student);
        public void Delete(int id);
        public Student GetEmail(string email);
    }
    public class StudentRepo:IStudentRepo
    {
        ITIContext db;

        public StudentRepo(ITIContext _db)
        {
            db = _db;
        }
        public List<Student> GetAll()
        {
            return db.Students.Include(a => a.Department).ToList();
        }
        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(a => a.Id == id);
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var std = GetById(id);
            db.Students.Remove(std);
            db.SaveChanges();
        }
        public Student GetEmail(string email)
        {
            return db.Students.FirstOrDefault(a => a.Email == email);
        }
    }
}
