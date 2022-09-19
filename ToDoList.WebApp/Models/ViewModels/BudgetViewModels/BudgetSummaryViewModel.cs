using System.Collections.Generic;
using Todo.Domain.Entities.Budgets;

namespace ToDoList.WebApp.Models.ViewModels.BudgetViewModels
{
    public class BudgetSummaryViewModel
    {
        public string Title { get; set; }

        public IList<Income> Incomes { get; set; }

        public IList<Expense> Expenses { get; set; }

        public decimal TotalIncomes { get; set; }

        public decimal TotalExpenses { get; set; }
    }
}
