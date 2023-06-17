namespace LearnASPCoreMVC.Models
{
	public class StudentCourse
	{
		public int Id { get; set; }

		public int StudentID { get; set; }

		public int CourseID { get; set; }

		public Student Student { get; set; }

		public Course Course { get; set; }
	}
}
