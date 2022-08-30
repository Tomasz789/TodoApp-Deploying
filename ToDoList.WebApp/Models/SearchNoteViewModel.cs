using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.WebApp.Models
{
    public class SearchNoteViewModel
    {
        public string Title { get; set; }

        [Display(Name ="Date created from:")]
        public DateTime CreatedDateFrom { get; set; } = DateTime.Now.AddDays(-7);

        [Display(Name = "Date created to:")]
        public DateTime CreatedDateTo { get; set; } = DateTime.Now;

        [Display(Name ="Order by:")]
        public string OrderType { get; set; }
    }
}
