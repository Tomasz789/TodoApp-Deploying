using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class CreateTaskListViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(4096, ErrorMessage ="Description must be max 4096 characters length.")]
        public string Description { get; set; }

        public string UserName { get; set; }
    }
}
