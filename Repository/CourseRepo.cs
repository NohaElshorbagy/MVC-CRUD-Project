using Lap3_2.Models;

namespace Lap3_2.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetAll();

        public Course GetById(int id);
    }
    public class CourseRepo:ICourseRepo
    {

        ITIContext db;

        public CourseRepo(ITIContext _db)
        {
            db = _db;
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(a => a.Id == id);
        }
    }
}
