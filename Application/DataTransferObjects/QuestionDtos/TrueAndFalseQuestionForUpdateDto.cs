using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record TrueAndFalseQuestionForUpdateDto : TrueAndFalseQuestionForManipulationDto
    {
        public static void UpdateTrueAndFalseQuestion(TrueAndFalseQuestionForUpdateDto questionForUpdateDto, TrueAndFalseQuestion question)
        {
            question.Title = questionForUpdateDto.Title;
            question.Difficulty = questionForUpdateDto.Difficulty;
            question.CorrectAnswer = questionForUpdateDto.CorrectAnswer;
            question.Mark  = questionForUpdateDto.Mark;
        }
    }



}
