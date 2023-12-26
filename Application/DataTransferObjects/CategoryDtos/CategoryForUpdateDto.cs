using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Application.DataTransferObjects.CategoryDtos
{
    public record CategoryForUpdateDto : CategoryForManipulationDto
    {
        public static void UpdateCategory(CategoryForUpdateDto categoryForUpdateDto, Category category)
        {
            category.Name = categoryForUpdateDto.Name!;
            category.Description = categoryForUpdateDto.Description!;
        }
    }

}
