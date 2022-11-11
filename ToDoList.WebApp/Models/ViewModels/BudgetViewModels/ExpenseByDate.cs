using System;

namespace ToDoList.WebApp.Models.ViewModels.BudgetViewModels
{
    public class ExpenseByDate
    {
        public DateTime Date { get; set; }

        public string Month { get; set; }

        public decimal TotalValue { get; set; }
    }
}
