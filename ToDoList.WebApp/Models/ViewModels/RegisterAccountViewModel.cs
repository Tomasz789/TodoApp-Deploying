using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class RegisterAccountViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "User name must be max 50 characters length.")]
        [MinLength(6, ErrorMessage = "User name must be 6 characters at least.")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [MinLength(8, ErrorMessage = "Password should have 8 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password are not the same.")]
        public string ConfirmedPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
