using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Objects.Models;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IEntityWithId
    {
        IQueryable<T> All();
        T Create(T entity);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        void Delete(T entity);
    }
}
