using Domain.Data;
using Domain.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IExamRepository> _examRepository;
        private readonly Lazy<IMultipleChoiceQuestionRepository> _multipleChoiceQuestionRepository;
        private readonly Lazy<ITrueAndFalseQuestionRepository> _trueAndFalseQuestionRepository;
        private readonly Lazy<IExamQuestionRepository> _examQuestionRepository;
        private readonly Lazy<IExamSolutionRepository> _examSolutionRepository;
        private readonly IServiceProvider _serviceProvider;

        public RepositoryManager(AppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _examRepository = new Lazy<IExamRepository>(() => new ExamRepository(_context));
            //_questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(_context));
            _multipleChoiceQuestionRepository = new Lazy<IMultipleChoiceQuestionRepository>(() => new MultipleChoiceQuestionRepository(_context));
            _trueAndFalseQuestionRepository = new Lazy<ITrueAndFalseQuestionRepository>(() => new TrueAndFalseQuestionRepository(_context));
            _examQuestionRepository = new Lazy<IExamQuestionRepository>(() => new ExamQuestionRepository(_context));
            _examSolutionRepository = new Lazy<IExamSolutionRepository>(() => new ExamSolutionRepository(_context));
            _serviceProvider = serviceProvider;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IExamRepository ExamRepository => _examRepository.Value;
        public IMultipleChoiceQuestionRepository MultipleChoiceQuestionRepository => _multipleChoiceQuestionRepository.Value;

        public ITrueAndFalseQuestionRepository TrueAndFalseQuestionRepository => _trueAndFalseQuestionRepository.Value;

        public IExamQuestionRepository ExamQuestionRepository => _examQuestionRepository.Value;

        public IExamSolutionRepository ExamSolutionRepository => _examSolutionRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public TRepository Repository<TRepository>()
            => (TRepository)_serviceProvider.GetRequiredService(typeof(TRepository));
    }
}
