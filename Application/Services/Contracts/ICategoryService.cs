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
        Task<CategoryDto> CreateCategory(CategoryForCreationDto categoryForCreationDto);
        Task UpdageCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges = false);
        Task DeleteCategory(Guid id, bool trackChanges = false);
    }
}
