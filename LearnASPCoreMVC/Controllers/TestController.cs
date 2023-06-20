using LearnASPCoreMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnASPCoreMVC.Controllers
{
    //[Route("[controller]")]
    public class TestController : Controller
    {
        private DataContext _dataContext;

        public TestController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //[Route("[action]")]
        public IActionResult Index()
        {
            ViewBag.test = new SelectList(_dataContext.Courses, "CourseID", "Title");
            return View();
        }
    }
}
