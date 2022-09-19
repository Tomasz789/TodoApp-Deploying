using System.Collections;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class TaskStatsViewModel
    {
        public int TasksCount { get; set; }

        public int TasksDoneCount { get; set; }

        public int TasksNotStarted { get; set; }

        public int TasksInProgressCount { get; set; }

        public int ListsCount { get; set; }

        public IEnumerable<TodoList> TodoLists { get; set; }

        public int TasksInCurrentList { get; set; }

        public int TaskDoneInCurrentList { get; set; }

        public int TaskUndoneInCurrentList { get; set; }

        public int TaskInProgressInCurrentList { get; set; }
    }
}
