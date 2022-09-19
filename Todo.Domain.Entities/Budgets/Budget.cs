using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities.Budgets
{
    public class Budget
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal StartBudgetValue { get; set; } = 0.0m;

        public decimal TotalBudgetValue { get; set; }

        public IEnumerable<Income> Incomes { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }

        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
