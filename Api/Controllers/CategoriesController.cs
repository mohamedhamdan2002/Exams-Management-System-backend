using Application.DataTransferObjects.CategoryDtos;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CategoriesController(IServiceManager services)
                =>  _services = services;

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _services.CategoryService.GetCategoriesAsync());
        }

        [HttpGet("{id:guid}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryAsync(Guid id) 
        {
            return Ok(await _services.CategoryService.GetCategoryByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCateogry([FromBody] CategoryForCreationDto category)
        {

            if (category is null)
                return BadRequest("CategoryFroCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var categoryDto = await _services.CategoryService.CreateCategory(category);
            return CreatedAtRoute("CategoryById", new { id = categoryDto.Id }, categoryDto);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category) 
        {
            if (category is null)
                return BadRequest("CategoryForUpdateDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _services.CategoryService.UpdageCategory(id, category, trackChanges: true);
            return NoContent();

        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _services.CategoryService.DeleteCategory(id);
            return NoContent();

        }
    }
}
