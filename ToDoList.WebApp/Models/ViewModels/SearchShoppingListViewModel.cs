using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models.ViewModels
{
    public class SearchShoppingListViewModel
    {
        public string Title { get; set; }

        [Display(Name = "Date created from:")]
        public DateTime CreatedDateFrom { get; set; } = DateTime.Now.AddDays(-28);

        [Display(Name = "Date created to:")]
        public DateTime CreatedDateTo { get; set; } = DateTime.Now;

        [Display(Name = "Due date from:")]

        public DateTime DueDateFrom { get; set; } = DateTime.Now.AddDays(-14);

        [Display(Name = "Due date to:")]

        public DateTime DueDateTo { get; set; } = DateTime.Now.AddDays(14);

        [Display(Name = "Order by date created:")]
        public string OrderByCreatedDateType { get; set; }

        [Display(Name = "Order by due date:")]
        public string OrderByDueDateType { get; set; }
    }
}
