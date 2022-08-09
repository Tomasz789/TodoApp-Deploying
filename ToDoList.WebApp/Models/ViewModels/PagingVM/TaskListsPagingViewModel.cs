using System.Collections.Generic;
using Todo.Domain.Entities;
using ToDoList.WebApp.Models.Paging;

namespace ToDoList.WebApp.Models.ViewModels.PagingVM
{
    public class TaskListsPagingViewModel
    {
        public IEnumerable<TodoList> Lists { get; set;}

        public PagingInfo PagingInfo { get; set; }
    }
}
