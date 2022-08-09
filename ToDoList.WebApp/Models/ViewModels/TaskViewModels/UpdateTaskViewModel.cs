using System;
using System.ComponentModel.DataAnnotations;
using Todo.Domain.Entities.TodoTaskStatus;

namespace ToDoList.WebApp.Models.ViewModels.TaskViewModels
{
    public class UpdateTaskViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Title should contain max. 100 characters.")]
        public string Title { get; set; }

        [MaxLength(4096, ErrorMessage = "Description can contain max. 4096 characters.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Ends at")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public TaskStatus StatusList { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public Priority PriorityList { get; set; }

        public int ListId { get; set; }
    }
}
