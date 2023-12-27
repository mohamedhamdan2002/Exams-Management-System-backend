﻿using Domain.Data;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    internal sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
        public void CreateCategory(Category category)
            => Create(category);

        public void DeleteCategory(Category category)
            => Delete(category);

        public async Task<IEnumerable<Category>> GetCategoriesAsync(bool trackChanges = false)
            => await GetAll(trackChanges).OrderBy(x => x.Name).ToListAsync();

        public async Task<Category?> GetCategoryByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperties)
            => await GetByCondition(c => c.Id == id, trackChanges, includeProperties).SingleOrDefaultAsync();

    }
}
