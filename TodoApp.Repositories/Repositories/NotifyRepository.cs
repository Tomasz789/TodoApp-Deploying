using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.RepositoryContracts;

namespace TodoApp.Repositories.Repositories
{
    public  class NotifyRepository : RepositoryBase<Notify>, INotifyRepository
    {
        public NotifyRepository(AppDatabaseContext context) : base(context)
        {

        }
    }
}
