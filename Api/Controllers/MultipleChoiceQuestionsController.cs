
using Application.DataTransferObjects.QuestionDtos;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleChoiceQuestionsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public MultipleChoiceQuestionsController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetMultipleChoiceQuestions()
        {
            return Ok(await _services
                .MultipleChoiceQuestionService
                .GetMultipleChoiceQuestionsAsync());
        }

        [HttpGet("{id:guid}", Name = "GetMultipleChoiceQuestionById")]
        public async Task<IActionResult> GetMultipleChoiceQuestion(Guid id)
        {
            var question = await _services.MultipleChoiceQuestionService.GetMultipleChoiceQuestionByIdAsync(id);
            return Ok(question);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMultipleChoiceQuestion([FromBody] MultipleChoiceQuestionForCreationDto question)
        {
            if (question is null)
                return BadRequest("MultipleChoiceQuestionForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var questionToReturn = await _services.MultipleChoiceQuestionService.CreateMultipleChoiceQuestionAsync(question);
            return CreatedAtRoute("GetMultipleChoiceQuestionById", new { id = questionToReturn.Id }, questionToReturn);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateMultipleChoiceQuestion(Guid id, [FromBody] MultipleChoiceQuestionForUpdateDto question)
        {
            if (question is null)
                return BadRequest("MultipleChoiceQuestionForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.MultipleChoiceQuestionService.UpdateMultipleChoiceQuestionAsync(id, question);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMultipleChoiceQuestion(Guid id)
        {
             await _services.MultipleChoiceQuestionService.DeleteMultipleChoiceQuestionAsync(id);
            return NoContent();
        }
    }
}
