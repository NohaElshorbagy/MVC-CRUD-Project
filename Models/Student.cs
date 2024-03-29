using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lap3_2.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =3)]
        public string Name { get; set; }
        [Range(20,30)]
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int DeptNo { get; set; }
        [Required]
        [Remote("CheckEmail" , "Student")]
        public string Email { get; set; }
        [NotMapped]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }
        //Navigation Property 
        public Department? Department { get; set; }
        public List<StudentCourse>? StudentCourse { get; set; }
    }
}
