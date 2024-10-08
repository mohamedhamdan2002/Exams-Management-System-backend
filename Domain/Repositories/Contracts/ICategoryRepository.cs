﻿using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(bool trackChanges = false);
        Task<Category?> GetCategoryByIdAsync(Guid id,  bool trackChanges = false, params string[] includeProperties);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
