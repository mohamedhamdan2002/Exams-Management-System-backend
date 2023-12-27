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
        private readonly Lazy<IExamService> _examService;

        public ServiceManager(IRepositoryManager repository)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository));
            _examService = new Lazy<IExamService>(() => new ExamService(repository));
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public IExamService ExamService => _examService.Value;
    }
}
