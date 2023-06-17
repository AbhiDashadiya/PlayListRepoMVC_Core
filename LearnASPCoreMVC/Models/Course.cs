namespace LearnASPCoreMVC.Models
{
	public class Course
	{
		public int CourseID { get; set; }

		public string Title { get; set; }

		public int Code { get; set; }

		public ICollection<StudentCourse> Enroll { get; set; }
	}
}
