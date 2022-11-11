using System.Collections.Generic;
using Todo.Domain.Entities.Budgets;

namespace ToDoList.WebApp.Models.ViewModels.BudgetViewModels
{
    public class BudgetSummaryViewModel
    {
        public string Title { get; set; }

        public IList<Income> Incomes { get; set; }

        public IList<Expense> Expenses { get; set; }

        public IList<ExpenseByDate> ExpensesByDate { get; set; }

        public IList<IncomeByDate> IncomesByDate { get; set; }
        public decimal TotalIncomes { get; set; }

        public decimal TotalExpenses { get; set; }

        public decimal TotalIncomesCurrentMonth { get; set; }

        public decimal TotalExpensesCurrentMonth { get; set; }

        public decimal TotalIncomesCurrentYear { get; set; }

        public decimal TotalExpensesCurrentYear { get; set; }

        public decimal TotalIncomesCurrentWeek { get; set; }

        public decimal TotalExpensesCurrentWeek { get; set; }
    }
}
