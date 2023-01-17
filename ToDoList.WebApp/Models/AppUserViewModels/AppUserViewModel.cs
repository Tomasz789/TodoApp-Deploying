using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.AppUserViewModels
{
    public class AppUserViewModel
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

        [Display(Name = "Avatar photo")]
        public string PhotoPath { get; set; }

        public IFormFile Photo { get; set; }

    }
}
