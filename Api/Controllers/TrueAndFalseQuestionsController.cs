

// Ignore Spelling: Api

using Application.DataTransferObjects.QuestionDtos;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class TrueAndFalseQuestionsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public TrueAndFalseQuestionsController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrueAndFalseQuestions()
        {
            return Ok(await _services
                .TrueAndFalseQuestionService
                .GetTrueAndFalseQuestionsAsync());
        }

        [HttpGet("{id:guid}", Name = "GetTrueAndFalseQuestionById")]
        public async Task<IActionResult> GetTrueAndFalseQuestion(Guid id)
        {
            var question = await _services.TrueAndFalseQuestionService.GetTrueAndFalseQuestionByIdAsync(id);
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrueAndFalseQuestion([FromBody] TrueAndFalseQuestionForCreationDto question)
        {
            if (question is null)
                return BadRequest("TrueAndFalseQuestionForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var questionToReturn = await _services.TrueAndFalseQuestionService.CreateTrueAndFalseQuestionAsync(question);
            return CreatedAtRoute("GetTrueAndFalseQuestionById", new { id = questionToReturn.Id }, questionToReturn);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTrueAndFalseQuestion(Guid id, [FromBody] TrueAndFalseQuestionForUpdateDto question)
        {
            if (question is null)
                return BadRequest("TrueAndFalseQuestionForUpdateDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.TrueAndFalseQuestionService.UpdateTrueAndFalseQuestionAsync(id, question, trackChanges: true);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTrueAndFalseQuestion(Guid id)
        {
            await _services.TrueAndFalseQuestionService.DeleteTrueAndFalseQuestionAsync(id);
            return NoContent();
        }
    }
}
