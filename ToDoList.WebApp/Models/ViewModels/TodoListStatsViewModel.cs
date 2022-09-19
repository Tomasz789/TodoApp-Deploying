using System.Collections.Generic;
using Todo.Domain.Entities;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class TodoListStatsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int CurrentTaskId { get; set; }

        public IEnumerable<TodoTask>  Tasks { get; set; }

        public IEnumerable<TodoTask> InProgress { get; set; }

        public IEnumerable<TodoTask> Done { get; set; }

        public IEnumerable<TodoTask> Undone { get; set; }
    }
}
