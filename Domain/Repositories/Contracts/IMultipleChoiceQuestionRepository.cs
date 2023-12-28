using Domain.Entities.Models;

namespace Domain.Repositories.Contracts
{
    public interface IMultipleChoiceQuestionRepository
    {
        Task<IEnumerable<MultipleChoiceQuestion>> GetMultipleChoiceQuestionsAsync(bool trackChanges = false);
        Task<MultipleChoiceQuestion?> GetMultipleChoiceQuestionByIdAsync(Guid id,
            bool tarckChanges = false,
            params string[] includeProperties);
        void CreateMultipleChoiceQuestion(MultipleChoiceQuestion question);

        void DeleteMultipleChoiceQuestion(MultipleChoiceQuestion question);
    }
}
