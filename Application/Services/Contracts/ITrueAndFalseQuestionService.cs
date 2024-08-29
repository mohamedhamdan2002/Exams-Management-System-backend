using Application.DataTransferObjects.QuestionDtos;

namespace Application.Services.Contracts
{
    public interface ITrueAndFalseQuestionService
    {
        Task<IEnumerable<TrueAndFalseQuestionDto>> GetTrueAndFalseQuestionsAsync(bool trackChanges = false);
        Task<TrueAndFalseQuestionDto> GetTrueAndFalseQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites);
        Task<QuestionDto> CreateTrueAndFalseQuestionAsync(TrueAndFalseQuestionForCreationDto questionForCreationDto);
        Task UpdateTrueAndFalseQuestionAsync(Guid id, TrueAndFalseQuestionForUpdateDto questionForUpdateDto, bool trackChanges = false);
        Task DeleteTrueAndFalseQuestionAsync(Guid id, bool trackChanges = false);
    }
}
