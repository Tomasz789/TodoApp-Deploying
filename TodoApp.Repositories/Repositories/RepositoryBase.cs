using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TodoApp.DAL.DataContext;
using TodoApp.DAL.RepositoryContracts;
#pragma warning disable S3442 // "abstract" classes should not have "public" constructors

namespace TodoApp.Repositories.Repositories
{
    public abstract class RepositoryBase<T>  : IRepository<T> where T : class
    {
        protected AppDatabaseContext Context { get; set; }

        public RepositoryBase(AppDatabaseContext context)
        {
            this.Context = context;
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression).AsNoTracking();
        }

        public T GetOneByCondition(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().FirstOrDefault(expression);
        }
    }
}
