using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
    }
}
