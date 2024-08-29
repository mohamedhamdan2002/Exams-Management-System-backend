using Application.Services.Contracts;
using Domain.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IExamService> _examService;
        private readonly Lazy<IMultipleChoiceQuestionService> _multipleChoiceQuestionService;
        private readonly Lazy<ITrueAndFalseQuestionService> _trueAndFalseQuestionService;
        private readonly Lazy<IExamQuestionService> _examQuestionService;
        private readonly Lazy<IExamSolutionService> _examSolutionService;
        private readonly IServiceProvider _serviceProvider;

        public ServiceManager(IRepositoryManager repository, IServiceProvider serviceProvider)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository));
            _examService = new Lazy<IExamService>(() => new ExamService(repository));
            _multipleChoiceQuestionService = new Lazy<IMultipleChoiceQuestionService>(() => new MultipleChoiceQuestionService(repository));
            _trueAndFalseQuestionService = new Lazy<ITrueAndFalseQuestionService>(() => new TrueAndFalseQuestionService(repository));
            _examQuestionService = new Lazy<IExamQuestionService>(() => new ExamQuestionService(repository));
            _examSolutionService = new Lazy<IExamSolutionService>(() => new ExamSolutionService(repository));  
            _serviceProvider = serviceProvider;
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public IExamService ExamService => _examService.Value;

        

        public IMultipleChoiceQuestionService MultipleChoiceQuestionService => _multipleChoiceQuestionService.Value;
        public ITrueAndFalseQuestionService TrueAndFalseQuestionService => _trueAndFalseQuestionService.Value;

        public IExamQuestionService ExamQuestionService => _examQuestionService.Value;

        public IAuthService AuthService => Service<IAuthService>();

        public IExamSolutionService ExamSolutionService => _examSolutionService.Value;

        public TService Service<TService>()
            => (TService)_serviceProvider.GetRequiredService(typeof(TService));


    }
}
