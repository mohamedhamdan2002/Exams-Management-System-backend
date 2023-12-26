using Application.Services.Contracts;
using Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;

        public ServiceManager(IRepositoryManager repository,ICategoryService categoryService)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository));
        }

        public ICategoryService CategoryService => _categoryService.Value;
    }
}
