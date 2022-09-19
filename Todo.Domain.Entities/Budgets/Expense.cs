using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities.Budgets
{
    public class Expense
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal ExpenseValue { get; set; }

        public Currency ExpenseCurrency { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }

        public string PhotoPath { get; set; }

    }
}
