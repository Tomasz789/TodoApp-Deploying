using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.RepositoryContracts;

namespace TodoApp.Repositories.Repositories
{
    internal class NoteRepository : RepositoryBase<Note>, INoteRepository
    {
        public NoteRepository(AppDatabaseContext context) : base(context)
        {
        }
    }
}
