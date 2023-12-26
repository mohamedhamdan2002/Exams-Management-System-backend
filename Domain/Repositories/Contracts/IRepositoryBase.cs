using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    internal interface IRepositoryBase<T> where T : class 
    {
        void Create(T entity);
        void Delete(T entity);

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate, bool trackChanges = false, params string[] includeProperties);
    }
}
