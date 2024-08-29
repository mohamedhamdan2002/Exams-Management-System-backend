using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICategoryRepository CategoryRepository { get; }
        IExamRepository ExamRepository { get; }
        IMultipleChoiceQuestionRepository MultipleChoiceQuestionRepository { get; }
        ITrueAndFalseQuestionRepository TrueAndFalseQuestionRepository { get; }
        IExamQuestionRepository ExamQuestionRepository { get; }
        IExamSolutionRepository ExamSolutionRepository { get; }
        Task SaveAsync();
    }
}
