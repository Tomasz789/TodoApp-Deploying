using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.RepositoryContracts;

namespace TodoApp.Repositories.Repositories
{
    public class TodoListRespository : RepositoryBase<TodoList>, ITodoListRepository
    {
        public TodoListRespository(AppDatabaseContext context) : base(context)
        {
        }

    }
}
