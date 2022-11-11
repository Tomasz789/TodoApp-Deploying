using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.AppUserViewModels
{
    public class AppUserViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

        [Display(Name = "Profile photo")]
        public string PhotoPath { get; set; }
    }
}
