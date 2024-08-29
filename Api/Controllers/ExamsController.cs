// Ignore Spelling: Api

using Api.Hubs;
using Application.DataTransferObjects.ExamDtos;
using Application.Services.Contracts;
using Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers
{
    [Route("api/categories/{categoryId:guid}/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamsController : ControllerBase
    {
        private readonly IServiceManager _services;
        private readonly IHubContext<NotificationHub, INotificationClient> _notificationHub;

        public ExamsController(
            IServiceManager serviceManager,
            IHubContext<NotificationHub, INotificationClient> notificationHub
            )
        {
            _services = serviceManager;
            _notificationHub = notificationHub;
        }
        [HttpGet("~/api/exams")]
        public async Task<IActionResult> GetExams()
        {
            return Ok(await _services.ExamService.GetExamsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetExamsForCategory(Guid categoryId)
        {
            return Ok(await _services.Service<IExamService>().GetExamsForCategoryAsync(categoryId));
            //return Ok(await _services.ExamService.GetExamsForCategoryAsync(categoryId));
        }
        [HttpGet("{id:guid}", Name = "GetExamForCategory")]
        public async Task<IActionResult> GetExamForCategory(Guid categoryId, Guid id)
        {
            ExamDto examDto = await _services.ExamService.GetExamForCategoryAsync(categoryId, id,
                    includeProperites: NavigationPropertiesConstant.QuestionsThenQuestion);
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
            await _notificationHub.Clients.All.onNewExamCreated(
                new ExamNotificationDto(
                        Title: examDto.Title!,
                        Category: examDto.Category!,
                        Date: examDto.Date
                    )
            );
            return CreatedAtRoute("GetExamForCategory", new { categoryId, id = examDto.Id }, examDto);

        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> CreateExamForCategory(Guid categoryId, Guid id, [FromBody] ExamForUpdateDto exam)
        {
            if (exam is null)
                return BadRequest("ExamForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.ExamService.UpdateExamForCategoryAsync(categoryId, id, exam);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteExamForCategory(Guid categoryId, Guid id)
        {
            await _services.ExamService.DeleteExamForCategoryAsync(categoryId, id);
            return NoContent();
        }
        //[HttpGet("{guid:id}")]
        //public async Task<IActionResult> GetExamQuestions(Guid categoryId, Guid id)
        //{
        //    var examsWithQuestions =
        //    return Ok(examsWithQuestions);

        //}
    }
}
