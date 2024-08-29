using Domain.Entities.Models;

namespace Domain.Repositories.Contracts
{
    public interface IMultipleChoiceQuestionRepository : IRepositoryBase<MultipleChoiceQuestion>
    {
        Task<IEnumerable<MultipleChoiceQuestion>> GetMultipleChoiceQuestionsAsync(bool trackChanges = false);
        Task<MultipleChoiceQuestion?> GetMultipleChoiceQuestionByIdAsync(Guid id,
            bool tarckChanges = false,
            params string[] includeProperties);
        Task<Dictionary<Guid, MultipleChoiceQuestion>> GetMCQuestionsForExam(Guid examId);

    }
}
