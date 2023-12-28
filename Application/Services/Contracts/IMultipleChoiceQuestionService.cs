using Application.DataTransferObjects.QuestionDtos;

namespace Application.Services.Contracts
{
    public interface IMultipleChoiceQuestionService
    {
        Task<IEnumerable<MultipleChoiceQuestionDto>> GetMultipleChoiceQuestionsAsync(bool trackChanges = false);
        Task<MultipleChoiceQuestionDto> GetMultipleChoiceQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites);
        Task<QuestionDto> CreateMultipleChoiceQuestionAsync(MultipleChoiceQuestionForCreationDto questionForCreationDto);
        Task UpdateMultipleChoiceQuestionAsync(Guid id, MultipleChoiceQuestionForUpdateDto questionForUpdateDto, bool trackChanges = false);
        Task DeleteMultipleChoiceQuestionAsync(Guid id, bool trackChanges = false);
    }


}
