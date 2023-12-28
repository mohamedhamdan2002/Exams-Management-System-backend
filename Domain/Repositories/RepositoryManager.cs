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
        private readonly AppDbContext _context;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IExamRepository> _examRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<IMultipleChoiceQuestionRepository> _multipleChoiceQuestionRepository;
        private readonly Lazy<ITrueAndFalseQuestionRepository> _trueAndFalseQuestionRepository;
        
        public RepositoryManager(AppDbContext context)
        {
            _context = context;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
            _examRepository = new Lazy<IExamRepository>(() => new ExamRepository(_context));
            _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(_context));
            _multipleChoiceQuestionRepository = new Lazy<IMultipleChoiceQuestionRepository>(() => new MultipleChoiceQuestionRepository(_context));
            _trueAndFalseQuestionRepository = new Lazy<ITrueAndFalseQuestionRepository>(() => new TrueAndFalseQuestionRepository(_context));
        }
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public IExamRepository ExamRepository => _examRepository.Value;

        public IQuestionRepository QuestionRepository => _questionRepository.Value;

        public IMultipleChoiceQuestionRepository MultipleChoiceQuestionRepository => _multipleChoiceQuestionRepository.Value;

        public ITrueAndFalseQuestionRepository TrueAndFalseQuestionRepository => _trueAndFalseQuestionRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
