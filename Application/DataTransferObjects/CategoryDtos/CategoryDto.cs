using Domain.Entities.Models;

namespace Application.DataTransferObjects.CategoryDtos
{
    public record CategoryDto 
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }

        public static CategoryDto ToCategoryDto(Category entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }
        public static IEnumerable<CategoryDto> ToListOfCategoriesDto(IEnumerable<Category> categories)
        {
            return categories.Select(category => ToCategoryDto(category));
        }
    }
}
