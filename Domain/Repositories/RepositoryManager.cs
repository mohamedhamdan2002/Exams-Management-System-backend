using Domain.Data;
using Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly AppDbContext _context;
        public RepositoryManager(AppDbContext context)
        {
            _context = context;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
        }
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
