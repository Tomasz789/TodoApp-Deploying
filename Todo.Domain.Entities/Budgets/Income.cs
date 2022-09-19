using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Domain.Entities.Budgets
{
    public class Income
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal IncomeValue { get; set; }

        public Currency IncomeCurrency { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }

        public virtual AppUser User { get; set; }
    }
}
