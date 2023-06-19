using Microsoft.AspNetCore.Mvc;

namespace LearnASPCoreMVC.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowData(string first)
        {
            ViewBag.First = first;
            return View();
        }

    }
}
