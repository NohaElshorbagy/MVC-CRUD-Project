using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lap3_2.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Department ID")]
        public int DeptId { get; set; }

        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        //Navigation Property
        public ICollection<Student> Students { get; set; } =new HashSet<Student>();
        public List<Course> Courses { get; set; }
    }
}
