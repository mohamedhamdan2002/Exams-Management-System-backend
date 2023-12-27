using Application.DataTransferObjects.CategoryDtos;
using Application.DataTransferObjects.ExamDtos;
using Application.Services.Contracts;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/categories/{categoryId:guid}/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ExamsController(IServiceManager serviceManager)
        {
            _services = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetExamsForCategory(Guid categoryId)
        {
            return Ok(await _services.ExamService.GetExamsForCategoryAsync(categoryId));
        }
        [HttpGet("{id:guid}", Name = "GetExamForCategory")]
        public async Task<IActionResult> GetExamForCategory(Guid categoryId, Guid id)
        {
            ExamDto examDto = await _services.ExamService.GetExamForCategoryAsync(categoryId, id);
            return Ok(examDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExamForCategory(Guid categoryId, [FromBody] ExamForCreationDto exam)
        {
            if (exam is null)
                return BadRequest("ExamForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            ExamDto examDto = await _services.ExamService.CreateExamForCategoryAsync(categoryId, exam);
            return CreatedAtRoute("GetExamForCategory", new { categoryId, id = examDto.Id }, examDto);

        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> CreateExamForCategory(Guid categoryId, Guid id, [FromBody] ExamForUpdateDto exam)
        {
            if (exam is null)
                return BadRequest("ExamForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.ExamService.UpdageExamForCategoryAsync(categoryId, id, exam);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteExamForCategory(Guid categoryId, Guid id)
        {
            await _services.ExamService.DeleteExamForCategoryAsync(categoryId, id);
            return NoContent();
        }
    }
}
