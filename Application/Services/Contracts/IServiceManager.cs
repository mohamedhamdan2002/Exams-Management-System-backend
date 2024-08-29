using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IServiceManager 
    {
        TService Service<TService>();
        ICategoryService CategoryService { get; }
        IExamService ExamService { get; }
        IMultipleChoiceQuestionService MultipleChoiceQuestionService { get; }
        ITrueAndFalseQuestionService TrueAndFalseQuestionService { get; }
        IExamQuestionService ExamQuestionService { get; }
        IExamSolutionService ExamSolutionService { get; }
        IAuthService AuthService { get; }
    }
}
