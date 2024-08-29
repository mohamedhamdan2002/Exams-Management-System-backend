using Domain.Entities.Models;

namespace Domain.Repositories.Contracts
{
    public interface ITrueAndFalseQuestionRepository : IRepositoryBase<TrueAndFalseQuestion>
    {
        Task<IEnumerable<TrueAndFalseQuestion>> GetTrueAndFalseQuestionsAsync(bool trackChanges = false);
        Task<TrueAndFalseQuestion?> GetTrueAndFalseQuestionByIdAsync(Guid id,
            bool tarckChanges = false,
            params string[] includeProperties);
        Task<bool> CheckIfItExistsByIdAsync(Guid id);
        Task<Dictionary<Guid, TrueAndFalseQuestion>> GetTFQuestionsForExam(Guid examId);
    }
}
