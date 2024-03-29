using Microsoft.EntityFrameworkCore;

namespace Lap3_2.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = Test3 ;Integrated Security = true ;TrustServerCertificate = true");
            base.OnConfiguring(optionsBuilder);
        }
        public ITIContext()
        {
            
        }
        public ITIContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(
                a => new { a.Student_Id, a.Course_Id });
            base.OnModelCreating(modelBuilder);
        }
    }
}
