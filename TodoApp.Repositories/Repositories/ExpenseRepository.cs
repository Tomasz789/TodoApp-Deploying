using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities.Budgets;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.RepositoryContracts;

namespace TodoApp.Repositories.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(AppDatabaseContext context) : base(context)
        {
        }
    }
}
