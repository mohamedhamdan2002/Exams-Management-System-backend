using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record MultipleChoiceQuestionForUpdateDto : MultipleChoiceQuestionForManipulationDto
    {
        public static void UpdateMultipleChoiceQuestion(MultipleChoiceQuestionForUpdateDto questionForUpdateDto, MultipleChoiceQuestion question)
        {
            question.Title = questionForUpdateDto.Title;
            question.Mark = questionForUpdateDto.Mark;
            question.Difficulty = questionForUpdateDto.Difficulty;
            question.OptionA = questionForUpdateDto.OptionA;
            question.OptionB = questionForUpdateDto.OptionB;
            question.OptionC = questionForUpdateDto.OptionC;
            question.OptionD = questionForUpdateDto.OptionD;
            question.CorrectChoice = questionForUpdateDto.CorrectChoice;
        }
    }



}
