using Domain.Entities.Models;

namespace Domain.Repositories.Contracts
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetExamsForCategoryAsync(Guid categoryId, bool trackChanges = false);
        Task<Exam?> GetExamForCatogoryAsync(Guid categoryId, Guid id, bool trackChanges = false, params string[] includeProperties);
        void CreateExamForCategory(Guid categoryId, Exam exam);
        void DeleteExam(Exam exam);
    }
}
