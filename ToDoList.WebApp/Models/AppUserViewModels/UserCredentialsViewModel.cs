using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.AppUserViewModels
{
    public class UserCredentialsViewModel
    {
        [Required]
        [Display(Name = "User name:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password: ")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
