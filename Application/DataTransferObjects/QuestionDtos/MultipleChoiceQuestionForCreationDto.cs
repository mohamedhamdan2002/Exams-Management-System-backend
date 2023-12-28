using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record MultipleChoiceQuestionForCreationDto : MultipleChoiceQuestionForManipulationDto
    {
        public static MultipleChoiceQuestion ToMultipleChoiceQuestion(MultipleChoiceQuestionForCreationDto question)
        {
            return new MultipleChoiceQuestion
            {
                Title = question.Title,
                Mark = question.Mark,
                Difficulty = question.Difficulty,
                OptionA = question.OptionA,
                OptionB = question.OptionB,
                OptionC = question.OptionC,
                OptionD = question.OptionD,
                CorrectChoice = question.CorrectChoice,
            };
        }
    }



}
