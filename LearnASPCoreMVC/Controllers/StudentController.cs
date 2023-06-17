using Microsoft.AspNetCore.Mvc;

namespace LearnASPCoreMVC.Controllers
{
	public class StudentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
