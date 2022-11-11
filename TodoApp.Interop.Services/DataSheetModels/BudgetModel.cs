using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities.Budgets;

namespace TodoApp.Interop.Services.DataSheetModels
{
    public class BudgetModel
    {
        public string Title { get; set; }
        public IEnumerable<Income> Incomes { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }
    }
}
