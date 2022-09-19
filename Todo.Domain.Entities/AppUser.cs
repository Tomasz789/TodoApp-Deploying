using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Todo.Domain.Entities.Budgets;

namespace Todo.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string City { get; set; }

        [PersonalData]
        public string Country { get; set; }

        [PersonalData]
        public DateTime BirthDate { get; set; } = new DateTime(2000, 1, 1);

        public string PhotoPath { get; set; }

        public IQueryable<TodoList> TodoLists { get; set; }

        public IQueryable<Note> Notes { get; set; }

        public IQueryable<ShoppingList> ShoppingLists { get; set; }

        public IQueryable<Income> Incomes { get; set; }

        public IQueryable<Expense> Expenses { get; set; }
    }
}
