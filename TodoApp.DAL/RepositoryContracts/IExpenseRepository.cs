using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities.Budgets;

namespace TodoApp.DAL.RepositoryContracts
{
    public interface IExpenseRepository : IRepository<Expense>
    {
    }
}
