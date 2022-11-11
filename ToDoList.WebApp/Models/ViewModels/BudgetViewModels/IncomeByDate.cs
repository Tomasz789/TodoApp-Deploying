using System;

namespace ToDoList.WebApp.Models.ViewModels.BudgetViewModels
{
    public class IncomeByDate
    {
        public DateTime Date { get; set; }

        public string Month { get; set; }

        public decimal TotalValue { get; set; }
    }
}
