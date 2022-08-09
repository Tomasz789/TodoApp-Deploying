using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.RepositoryContracts;
using TodoApp.DAL.Wrappers;

namespace TodoApp.Repositories.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDatabaseContext context;
        private IUserRepository userRepository;
        private ITodoListRepository listRepository;
        private ITodoTaskRepository todoTaskRepository;

        public RepositoryWrapper(AppDatabaseContext context)
        {
            this.context = context;
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository =  new UserRepository(context);
                }

                return userRepository;
            }
        }

        public ITodoListRepository TodoListRepository
        {
            get
            {
                if (listRepository == null)
                {
                    listRepository = new TodoListRespository(context);
                }

                return listRepository;
            }
        }

        public ITodoTaskRepository TodoTaskRepository
        {
            get
            {
                if (todoTaskRepository == null)
                {
                    todoTaskRepository = new TodoTaskRepository(context);
                }

                return todoTaskRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
