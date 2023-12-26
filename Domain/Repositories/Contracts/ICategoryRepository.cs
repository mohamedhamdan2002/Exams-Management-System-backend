using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(bool trackChanges);
        Task<Category?> GetCategoryById(Guid id,  bool trackChanges);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
