using Application.DataTransferObjects.IDs;
using Application.Services.Contracts;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Exam/{examId}/Questions/")]
    [ApiController]
    [Authorize]
    public class ExamQuestionsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public ExamQuestionsController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetExamQuestions(Guid examId)
          {
            var examsWithQuestions = await _services.ExamService.GetExamByIdAsync(examId, false,
                NavigationPropertiesConstant.QuestionsThenQuestion , NavigationPropertiesConstant.Category);
            return Ok(examsWithQuestions);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddQuestionsToExam(Guid examId, [FromBody] List<QuestionIdDto> questionIds)
        {
            await _services.ExamQuestionService.AddQuestionsToExam(examId, questionIds);
            return NoContent();
        }
        
    }   

}
