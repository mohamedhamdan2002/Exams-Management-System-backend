using Domain.Entities.Models;
using System.Linq.Expressions;

namespace Domain.Repositories.Contracts
{
    public interface IExamRepository
    {
        Task<IEnumerable<TResult>> GetExamsAsync<TResult>(Expression<Func<Exam, TResult>> selector, bool trackChanges = false);
        Task<IEnumerable<Exam>> GetExamsForCategoryAsync(Guid categoryId, bool trackChanges = false);
        Task<Exam?> GetExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false, params string[] includeProperties);
        Task<Exam?> GetExamAsync(Expression<Func<Exam, bool>> predicate, bool trackChanges = false, params string[] includeProperties);
        void CreateExamForCategory(Guid categoryId, Exam exam);
        void DeleteExam(Exam exam);
        Task<bool> CheckIfExamExistAsync(Guid id);
    }
}
