using Microsoft.AspNetCore.Identity;

namespace LearnASPCoreMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Lesbian,
        Gay,
        Bisexual,
        Transgender
    }

}
