using Application.DataTransferObjects.ExamDtos;
using Application.DataTransferObjects.IDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IExamQuestionService
    {
        Task AddQuestionToExam(Guid examId, Guid questionId);
        Task AddQuestionsToExam(Guid examId, IEnumerable<QuestionIdDto> questionIds);
        Task<ExamDto> GetExamByIdWithQuestionsAsync(Guid examId);
    }
}
