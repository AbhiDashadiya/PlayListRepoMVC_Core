using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearnASPCoreMVC.ViewModel
{
    public class CreateStudentViewModel
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public DateTime Enrolled { get; set; }

        public IList<SelectListItem> Courses { get; set; } = new List<SelectListItem>();
    }
}
