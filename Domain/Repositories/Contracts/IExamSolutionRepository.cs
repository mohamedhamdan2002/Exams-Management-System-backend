using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Linq.Expressions;

namespace Domain.Repositories.Contracts
{
    public interface IExamSolutionRepository
    {
        Task<IEnumerable<ExamSolution>> GetSolutionsForExam(Guid examId);
        Task<IEnumerable<TResult>> Get<TResult>(
                Expression<Func<ExamSolution, bool>> predicate,
                Expression<Func<ExamSolution, TResult>> selector,
                bool trackChanges = false,
                params string[] includeProperties
            );
        void CreateExamSolutionForExam(
            string userId, 
            Guid examId, 
            ExamSolution examSolution);
        Task<TResult?> GetExamResult<TResult>(
                string userId, 
                Guid examId, 
                Expression<Func<ExamSolution, TResult>> selector,
                bool trackChanges = false,
                params string[] includeProperties);
    }
}
