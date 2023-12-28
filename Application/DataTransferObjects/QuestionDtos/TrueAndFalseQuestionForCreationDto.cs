using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record TrueAndFalseQuestionForCreationDto : TrueAndFalseQuestionForManipulationDto
    {
        public static TrueAndFalseQuestion ToTrueAndFalseQuestion(TrueAndFalseQuestionForCreationDto question)
        {
            return new TrueAndFalseQuestion
            {
                Title = question.Title,
                Mark = question.Mark,
                Difficulty = question.Difficulty,
                CorrectAnswer = question.CorrectAnswer,
            };
        }

    }



}
