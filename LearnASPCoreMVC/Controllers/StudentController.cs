using LearnASPCoreMVC.Data;
using LearnASPCoreMVC.Models;
using LearnASPCoreMVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LearnASPCoreMVC.Controllers
{
    [Authorize(Roles = "Student,Admin")]
    public class StudentController : Controller
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }


        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }


        #region Get Methods

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return _context.Students != null ?
                        View(await _context.Students.ToListAsync()) :
                        Problem("Entity set 'DataContext.Students'  is null.");
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(e => e.EnrolledCourses)
                .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            var courses = _context.Courses.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.CourseID.ToString()
            }).ToList();
            CreateStudentViewModel vm = new CreateStudentViewModel();
            vm.Courses = courses;
            return View(vm);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(x => x.EnrolledCourses).FirstOrDefaultAsync(x => x.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            var selectedID = student.EnrolledCourses.Select(x => x.CourseID).ToList();
            var items = _context.Courses.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.CourseID.ToString(),
                Selected = selectedID.Contains(x.CourseID)
            }).ToList();

            CreateStudentViewModel model = new CreateStudentViewModel();
            model.StudentID = student.StudentID;
            model.Name = student.Name;
            model.Enrolled = student.Enrolled;
            model.Courses = items;


            return View(model);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        #endregion

        #region Post Methods

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentViewModel model)
        {
            Student student = new Student()
            {
                Name = model.Name,
                Enrolled = model.Enrolled,
            };

            var selectedCourses = model.Courses.Where(x => x.Selected).Select(x => Convert.ToInt32(x.Value)).ToList();

            foreach (var item in selectedCourses)
            {
                student.EnrolledCourses.Add(new StudentCourse() { CourseID = item });
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateStudentViewModel model)
        {
            // finding student
            Student existingStudent = _context.Students.Find(model.StudentID);


            // update name and enrollment data
            existingStudent.Name = model.Name;
            existingStudent.Enrolled = model.Enrolled;

            // find the student from student course table and find the course id's 
            var studentFromStudentCourseTable = _context.Students.Include(x => x.EnrolledCourses).FirstOrDefault(x => x.StudentID == model.StudentID);

            // find the existing course ids
            var existingCourse = studentFromStudentCourseTable.EnrolledCourses.Select(x => x.CourseID).ToList();
            // new ids which are select in model
            var newIdFromModel = model.Courses.Where(x => x.Selected).Select(x => int.Parse(x.Value)).ToList();

            // now find which id's to add
            var toAdd = newIdFromModel.Except(existingCourse).ToList();
            var toRemove = existingCourse.Except(newIdFromModel).ToList();

            existingStudent.EnrolledCourses = existingStudent.EnrolledCourses.Where(x => !toRemove.Contains(x.CourseID)).ToList();

            foreach (var item in toAdd)
            {
                existingStudent.EnrolledCourses.Add(new StudentCourse()
                {
                    CourseID = item
                });
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'DataContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion


    }
}
