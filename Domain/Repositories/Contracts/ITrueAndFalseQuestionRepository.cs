using Domain.Entities.Models;

namespace Domain.Repositories.Contracts
{
    public interface ITrueAndFalseQuestionRepository
    {
        Task<IEnumerable<TrueAndFalseQuestion>> GetTrueAndFalseQuestionsAsync(bool trackChanges = false);
        Task<TrueAndFalseQuestion?> GetTrueAndFalseQuestionByIdAsync(Guid id,
            bool tarckChanges = false,
            params string[] includeProperties);
        void CreateTrueAndFalseQuestion(TrueAndFalseQuestion question);

        void DeleteTrueAndFalseQuestion(TrueAndFalseQuestion question);
    }
}
