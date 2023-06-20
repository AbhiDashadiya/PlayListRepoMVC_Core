using LearnASPCoreMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearnASPCoreMVC.ViewModel;

namespace LearnASPCoreMVC.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course_Table");
            modelBuilder.Entity<Student>().ToTable("Student_Table");
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse_Table");

            modelBuilder.Entity<Student>().HasKey(x => x.StudentID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LearnASPCoreMVC.ViewModel.RoleStore> RoleStore { get; set; } = default!;

        public DbSet<LearnASPCoreMVC.ViewModel.AppUserViewModel> AppUserViewModel { get; set; } = default!;


    }
}
