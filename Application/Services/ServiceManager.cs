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
        private readonly Lazy<IQuestionService> _questionService;
        private readonly Lazy<IMultipleChoiceQuestionService> _multipleChoiceQuestionService;
        private readonly Lazy<ITrueAndFalseQuestionService> _trueAndFalseQuestionService;

        public ServiceManager(IRepositoryManager repository)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repository));
            _examService = new Lazy<IExamService>(() => new ExamService(repository));
            _questionService = new Lazy<IQuestionService>(() => new QuestionService(repository));
            _multipleChoiceQuestionService = new Lazy<IMultipleChoiceQuestionService>(() => new MultipleChoiceQuestionService(repository));
            _trueAndFalseQuestionService = new Lazy<ITrueAndFalseQuestionService>(() => new TrueAndFalseQuestionService(repository));
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public IExamService ExamService => _examService.Value;

        public IQuestionService QuestionService => _questionService.Value;

        public IMultipleChoiceQuestionService MultipleChoiceQuestionService => _multipleChoiceQuestionService.Value;
        public ITrueAndFalseQuestionService TrueAndFalseQuestionService => _trueAndFalseQuestionService.Value;
    }
}
