using LearnASPCoreMVC.Models;

namespace LearnASPCoreMVC.ViewModel
{
    public class AppUserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }
    }
}
