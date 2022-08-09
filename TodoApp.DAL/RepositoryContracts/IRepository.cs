using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TodoApp.DAL.RepositoryContracts
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);

        T GetOneByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
