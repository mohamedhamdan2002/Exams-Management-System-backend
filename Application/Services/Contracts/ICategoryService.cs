using Application.DataTransferObjects.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool trackChanges = false);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges = false , params string[] includeProperites);
        Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto);
        Task UpdageCategoryAsync(Guid id, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges = false);
        Task DeleteCategoryAsync(Guid id, bool trackChanges = false);
    }
}
