using Data.Context;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class, IEntityWithId
    {

        private AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> All()
        {
            var result = _context.Set<T>().AsQueryable<T>();
            return result;
        }

        public T Create(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Added;
            return entity;
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            var result = _context.Set<T>().Where(predicate);
            return result;
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            var result = await Filter(predicate).SingleOrDefaultAsync();
            return result;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_context == null)
            {
                return;
            }
            if (_context.Database != null && _context.Database.GetDbConnection().State != System.Data.ConnectionState.Closed)
            {
                try
                {
                    _context.Database.CloseConnection();
                }
                catch
                {
                    // Ignore
                }
            }
            _context.Dispose();
            _context = null;
        }
    }
}
