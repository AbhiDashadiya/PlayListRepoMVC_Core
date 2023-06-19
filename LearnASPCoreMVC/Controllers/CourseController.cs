using LearnASPCoreMVC.Data;
using LearnASPCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnASPCoreMVC.Controllers
{

    //[Authorize(Roles = "Student,Admin")]
    [Route("[controller]")]
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


        //[Route("Course")]
        //[Route("Course/Index")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            var courses = _dataContext.Courses.ToList();
            return View(courses);
        }

        //[Route("Course/Create")]
        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[Route("Course/Details/{id}")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult Details(int id)
        {
            var data = _dataContext.Courses.FirstOrDefault(x => x.CourseID == id);

            //ViewBag.Course = data;

            return View(data);
        }

        //[Route("Course/Edit/{id}")]
        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _dataContext.Courses.FirstOrDefault(x => x.CourseID == id);
            return View(data);
        }



        //[Route("Course/Delete/{id}")]
        [Route("[action]/{id}")]
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
