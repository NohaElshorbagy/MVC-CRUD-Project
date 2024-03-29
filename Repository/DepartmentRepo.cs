using Lap3_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lap3_2.Repository
{
    public interface IDeptRepo
    {
        public List<Department> GetAll();
        public Department GetById(int id);
        public void Add(Department department);
        public void Update(Department department);
        public void Delete(int id);
    }
    public class DepartmentRepo:IDeptRepo
    {
        ITIContext db;

        public DepartmentRepo(ITIContext _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.DeptId == id);
        }
        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }
        public void Delete(int id) 
        { 
            var dept = GetById(id);
            db.Departments.Remove(dept);
            db.SaveChanges();
        }
    }
}
