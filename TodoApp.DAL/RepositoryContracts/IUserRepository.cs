using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace TodoApp.DAL.RepositoryContracts
{
    public interface IUserRepository : IRepository<AppUser>
    {
       // User GetById(Guid id);

    }
}
