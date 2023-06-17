﻿namespace LearnASPCoreMVC.Models
{
	public class Student
	{
		public int StudentID { get; set; }

		public string Name { get; set; }

		public DateTime Enrolled { get; set; }

		public ICollection<StudentCourse> Enroll { get; set; }

	}
}
