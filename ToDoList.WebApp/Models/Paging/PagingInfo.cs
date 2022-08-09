using System;

namespace ToDoList.WebApp.Models.Paging
{
    /// <summary>
    /// Class represents information about paging - total items, items per page, current page and max page count.
    /// </summary>
    public class PagingInfo
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
