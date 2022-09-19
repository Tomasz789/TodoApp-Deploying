using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities.Budgets;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.RepositoryContracts;

namespace TodoApp.Repositories.Repositories
{
    public class IncomeRepository : RepositoryBase<Income>, IIncomeRepository
    {
        public IncomeRepository(AppDatabaseContext context) : base(context)
        {
        }
    }
}
