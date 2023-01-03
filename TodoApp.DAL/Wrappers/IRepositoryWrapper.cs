using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.DAL.RepositoryContracts;

namespace TodoApp.DAL.Wrappers
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }

        ITodoListRepository TodoListRepository { get; }

        ITodoTaskRepository TodoTaskRepository { get; }

        INoteRepository NoteRepository { get; }

        IShoppingListRepository ShoppingListRepository { get; }

        IIncomeRepository IncomeRepository { get; }

        IExpenseRepository ExpenseRepository { get; }

        INotifyRepository NotifyRepository { get; }

        void Save();
    }
}
