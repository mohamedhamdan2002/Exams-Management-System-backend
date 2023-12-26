using Application.DataTransferObjects.CategoryDtos;
using Application.Services.Contracts;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
namespace Application.Services
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repository;
        public CategoryService(IRepositoryManager repository) => _repository = repository;

        public async Task<CategoryDto> CreateCategory(CategoryForCreationDto categoryForCreationDto)
        {
            Category newCageoryEntity = CategoryForCreationDto.ToCategory(categoryForCreationDto);
            _repository.CategoryRepository.CreateCategory(newCageoryEntity);
            await _repository.SaveAsync();
            CategoryDto categoryDtoToReturn = CategoryDto.ToCategoryDto(newCageoryEntity);
            return categoryDtoToReturn;
        }

        public async Task DeleteCategory(Guid id, bool trackChanges = false)
        {
            Category cateogryToDelete = await getCategoryAndCheckIfItExits(id, trackChanges);
            _repository.CategoryRepository.DeleteCategory(cateogryToDelete);
            await _repository.SaveAsync();
        }


        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool trackChanges = false)
        {
            IEnumerable<Category> categories = await _repository.CategoryRepository.GetCategoriesAsync(trackChanges);
            return CategoryDto.ToListOfCategoriesDto(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            Category categoryEntity = await getCategoryAndCheckIfItExits(id, trackChanges);
            CategoryDto categoryDtoToReturn = CategoryDto.ToCategoryDto(categoryEntity);
            return categoryDtoToReturn;
        }

        public async Task UpdageCategory(Guid id, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges = false)
        {
            Category categoryEntity = await getCategoryAndCheckIfItExits(id, trackChanges);
            CategoryForUpdateDto.UpdateCategory(categoryForUpdateDto, categoryEntity);
            await _repository.SaveAsync();
        }
        private async Task<Category> getCategoryAndCheckIfItExits(Guid id, bool trackChanges = false)
        {
            Category? category = await _repository.CategoryRepository.GetCategoryById(id, trackChanges);
            if(category == null)
            {
                throw new Exception();
            }
            return category;
        }
    }
}
