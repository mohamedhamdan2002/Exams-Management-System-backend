using Application.DataTransferObjects.ExamSolutionDtos;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/exam-solutions")]
    [ApiController]
    [Authorize]
    public class ExamSolutionsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ExamSolutionsController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSolution(string userId,  Guid examId, [FromBody] SolutionForCreationDto solution)
        {
            await _service.ExamSolutionService.CreateExamSolution(userId, examId, solution);
            return StatusCode(201);
        }
        [HttpGet]
        public async Task<IActionResult> GetExamResult(string userId, Guid examId)
        {
            return Ok(await _service.ExamSolutionService.GetExamSolutionForUser(userId, examId));
        }
    }
}
