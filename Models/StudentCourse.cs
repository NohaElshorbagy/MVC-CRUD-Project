using System.ComponentModel.DataAnnotations.Schema;

namespace Lap3_2.Models
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        [ForeignKey("Course")]
        public int Course_Id { get; set; }
        public int Grade { get; set; }

        //Navigation property

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
