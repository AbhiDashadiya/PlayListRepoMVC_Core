using LearnASPCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnASPCoreMVC.Data
{
	public class DataContext : DbContext
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

		}


	}
}
