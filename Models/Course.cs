namespace Lap3_2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Crs_Name { get; set; }
        public int Duration { get; set; }

        //Navigation property 
        public List<Department> departments { get; set; }
        public List<StudentCourse> CourseStudent { get; set; }

    }
}
