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
        private INoteRepository noteRepository;
        private IShoppingListRepository shoppingListRepository;
        private IIncomeRepository incomeRepository;
        private IExpenseRepository expenseRepository;
        private INotifyRepository notifyRepository;

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

        public INoteRepository NoteRepository 
        {
            get
            {
                if (noteRepository == null)
                {
                    noteRepository =  new NoteRepository(context);
                }

                return noteRepository;
            }
        }

        public IShoppingListRepository ShoppingListRepository
        {
            get
            {
                if (shoppingListRepository == null)
                {
                    shoppingListRepository = new ShoppingListRepository(context);
                }

                return shoppingListRepository;
            }
        }

        public IIncomeRepository IncomeRepository
        {
            get
            {
                if (incomeRepository == null)
                {
                    incomeRepository = new IncomeRepository(context);
                }

                return incomeRepository;
            }
        }

        public IExpenseRepository ExpenseRepository
        {
            get
            {
                if (expenseRepository == null)
                {
                    expenseRepository = new ExpenseRepository(context);
                }

                return expenseRepository;
            }
        }

        public INotifyRepository NotifyRepository
        {
            get
            {
                if (notifyRepository == null)
                {
                    notifyRepository = new NotifyRepository(context);
                }

                return notifyRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
