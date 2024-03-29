using System.ComponentModel.DataAnnotations.Schema;

namespace Lap3_2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public int Age { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        //Navigation prop
        public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    }
}
