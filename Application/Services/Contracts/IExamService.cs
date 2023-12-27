using Application.DataTransferObjects.ExamDtos;

namespace Application.Services.Contracts
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>> GetExamsForCategoryAsync(Guid id, bool trackChanges = false);
        Task<ExamDto> GetExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false, params string[] includeProperites);
        Task<ExamDto> CreateExamForCategoryAsync(Guid categoryId, ExamForCreationDto examForCreationDto);
        Task UpdageExamForCategoryAsync(Guid categoryId, Guid id, ExamForUpdateDto examForUpdateDto, bool trackChanges = false);
        Task DeleteExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false);
    }
}
