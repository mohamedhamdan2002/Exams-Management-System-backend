using Application.DataTransferObjects.CategoryDtos;

namespace Application.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool trackChanges = false);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites);
        Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto);
        Task UpdateCategoryAsync(Guid id, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges = false);
        Task DeleteCategoryAsync(Guid id, bool trackChanges = false);
    }
}
