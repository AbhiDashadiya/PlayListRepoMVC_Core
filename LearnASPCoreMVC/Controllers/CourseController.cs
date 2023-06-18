using LearnASPCoreMVC.Data;
using LearnASPCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnASPCoreMVC.Controllers
{
	public class CourseController : Controller
	{
		private readonly DataContext _dataContext;

		public CourseController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}



		/// <summary>
		/// Http Get Methods
		/// </summary>
		/// <returns></returns>
		#region HttpGet

		[HttpGet]
		public IActionResult Index()
		{
			var courses = _dataContext.Courses.ToList();
			return View(courses);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var data = _dataContext.Courses.FirstOrDefault(x => x.CourseID == id);
			return View(data);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var data = _dataContext.Courses.FirstOrDefault(x => x.CourseID == id);
			return View(data);
		}

		public IActionResult Delete(int id)
		{
			var data = _dataContext.Courses.FirstOrDefault(x => x.CourseID == id);
			return View(data);
		}

		#endregion



		/// <summary>
		/// Http Post Methods
		/// </summary>
		/// <returns></returns>
		#region HttpPost

		[HttpPost]
		public IActionResult Create(Course model)
		{
			_dataContext.Courses.Add(model);
			_dataContext.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Edit(Course model)
		{
			_dataContext.Courses.Update(model);
			_dataContext.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Delete(Course model)
		{
			_dataContext.Courses.Remove(model);
			_dataContext.SaveChanges();
			return RedirectToAction("Index");
		}

		#endregion

	}


}
