using Domain.Entities.Models;

namespace Application.DataTransferObjects.CategoryDtos
{
    public record CategoryForCreationDto : CategoryForManipulationDto
    {
        public static Category ToCategory(CategoryForCreationDto categoryForCreationDto)
        {
            return new Category
            {
                Name = categoryForCreationDto.Name!,
                Description = categoryForCreationDto.Description!,
            };
        }
    }

}
