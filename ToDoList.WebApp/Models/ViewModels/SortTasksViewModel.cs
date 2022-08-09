using System;
using System.ComponentModel.DataAnnotations;
using Todo.Domain.Entities.TodoTaskStatus;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class SortTasksViewModel
    {
        public string Title { get; set; }

        [Display(Name ="Created date from:")]
        public DateTime CreatedDateFrom { get; set; } = DateTime.Now.AddDays(-7);

        [Display(Name = "Created date to:")]
        public DateTime CreatedDateTo { get; set; } = DateTime.Now;

        [Display(Name ="Due date from:")]
        public DateTime EndDateFrom { get; set; } = DateTime.Now.AddDays(-7);

        [Display(Name ="Due date to:")]
        public DateTime EndDateTo { get; set; } = DateTime.Now;

        public Priority Priority { get; set; }

        public TaskStatus Status { get; set; }
    }
}
