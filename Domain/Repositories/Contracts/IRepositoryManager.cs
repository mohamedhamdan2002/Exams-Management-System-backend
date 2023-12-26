using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICategoryRepository CategoryRepository { get; }
        Task SaveAsync();
    }
}
