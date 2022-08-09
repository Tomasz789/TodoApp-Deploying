using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class UpdateTaskListViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title should contain max 100 characters.")]
        public string Title { get; set; }

        [MaxLength(4096, ErrorMessage = "Description should contain max 4096 characters.")]
        public string Description { get; set; }

        public DateTime Updated { get; set; }

    }
}
