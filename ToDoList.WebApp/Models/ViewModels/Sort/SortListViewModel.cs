using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.WebApp.Models.ViewModels.Sort.SortTypes;

namespace ToDoList.WebApp.Models.ViewModels.Sort
{
    public class SortListViewModel
    {
        [Display(Name = "Created date from")]
        public DateTime CreatedDateMin { get; set; } = DateTime.Now.AddDays(-7);

        [Display(Name = "Created date to")]
        public DateTime CreatedDateMax { get; set;} = DateTime.Now;

        [Display(Name = "Sort")]
        public SortType SortType { get; set; }
    }
}
