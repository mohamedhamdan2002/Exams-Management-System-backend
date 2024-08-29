using Application.DataTransferObjects.CategoryDtos;
using Application.DataTransferObjects.ExamDtos;
using Application.Services.Contracts;
using Application.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CategoriesController(IServiceManager services)
                =>  _services = services;

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var data = await _services.CategoryService.GetCategoriesAsync();
            Response<IEnumerable<CategoryDto>> response = data.ToList();

            return Ok(response);
        }

        [HttpGet("{id:guid}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryAsync(Guid id) 
        {
            Response<CategoryDto> response = await _services.CategoryService.GetCategoryByIdAsync(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCateogry([FromBody] CategoryForCreationDto category)
        {

            if (category is null)
                return BadRequest("CategoryFroCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var categoryDto = await _services.CategoryService.CreateCategoryAsync(category);
            return CreatedAtRoute("CategoryById", new { id = categoryDto.Id }, categoryDto);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category) 
        {
            if (category is null)
                return BadRequest("CategoryForUpdateDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _services.CategoryService.UpdateCategoryAsync(id, category, trackChanges: true);
            return NoContent();

        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _services.CategoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
