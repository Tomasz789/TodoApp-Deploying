using System;
using System.Collections.Generic;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class FilterTaskListViewModel
    {
        public string Title { get; private set; }

        // unused and unnecessery
        public string Description { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime Updated { get; private set; }

        public IEnumerable<TodoTaskViewModel> Tasks { get; set; }

    }
}
