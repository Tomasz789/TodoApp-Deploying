using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class CreateShoppingListViewModel 
    {
        [Required]
        [Display(Name = "Title")]
        [MaxLength(255, ErrorMessage = "Maximum title length is 255.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        [MaxLength(4096, ErrorMessage = "Maximum length: 4096 characters.")]

        public string Description { get; set; }

        [Display(Name = "Due date")]
        public DateTime DueDate { get; set; } = DateTime.Now;
    }
}
