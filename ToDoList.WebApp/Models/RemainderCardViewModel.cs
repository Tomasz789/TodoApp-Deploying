using System.Collections.Generic;
using Todo.Domain.Entities;

namespace ToDoList.WebApp.Models
{
    public class RemainderCardViewModel
    {
        public IEnumerable<TodoList> Lists { get; set; }

        public int HighPriorityTaskAmount { get; set; }

        public int TotalTaskAmount { get; set; }
    }
}
