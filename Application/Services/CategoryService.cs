﻿// Ignore Spelling: Dto

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

        public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreationDto)
        {
            Category newCategoryEntity = CategoryForCreationDto.ToCategory(categoryForCreationDto);
            _repository.CategoryRepository.CreateCategory(newCategoryEntity);
            await _repository.SaveAsync();
            CategoryDto categoryDtoToReturn = CategoryDto.ToCategoryDto(newCategoryEntity);
            return categoryDtoToReturn;
        }

        public async Task DeleteCategoryAsync(Guid id, bool trackChanges = false)
        {
            Category categoryToDelete = await getCategoryAndCheckIfItExitsAsync(id, trackChanges);
            _repository.CategoryRepository.DeleteCategory(categoryToDelete);
            await _repository.SaveAsync();
        }


        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(bool trackChanges = false)
        {
            IEnumerable<Category> categories = await _repository.CategoryRepository.GetCategoriesAsync(trackChanges);
            return CategoryDto.ToListOfCategoriesDto(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperties)
        {
            Category categoryEntity = await getCategoryAndCheckIfItExitsAsync(id, trackChanges);
            CategoryDto categoryDtoToReturn = CategoryDto.ToCategoryDto(categoryEntity);
            return categoryDtoToReturn;
        }

        public async Task UpdateCategoryAsync(Guid id, CategoryForUpdateDto categoryForUpdateDto, bool trackChanges = false)
        {
            Category categoryEntity = await getCategoryAndCheckIfItExitsAsync(id, trackChanges);
            CategoryForUpdateDto.UpdateCategory(categoryForUpdateDto, categoryEntity);
            await _repository.SaveAsync();
        }
        private async Task<Category> getCategoryAndCheckIfItExitsAsync(Guid id, bool trackChanges = false)
        {
            Category? category = await _repository.CategoryRepository.GetCategoryByIdAsync(id, trackChanges);
            if (category == null)
            {
                throw new Exception();
            }
            return category;
        }
    }
}
