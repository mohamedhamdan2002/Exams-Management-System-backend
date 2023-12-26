using Domain.Data;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    { 
        private readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context) => _context = context;
        public void Create(T entity) => _context.Add(entity);

        public void Delete(T entity) => _context.Remove(entity);
        public IQueryable<T> GetAll(bool trackChanges = false)
            => !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>(); 
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate, bool trackChanges = false, params string[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);

            if (!trackChanges)
                query.AsNoTracking();

            if (includeProperties.Any())
                foreach (var property in includeProperties)
                    query.Include(property);

            return query;
        }
    }
}
