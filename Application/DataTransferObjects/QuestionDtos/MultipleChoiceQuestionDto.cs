using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record MultipleChoiceQuestionDto : QuestionDto
    {
        public string OptionA { get; init; }
        public string OptionB { get; init; }
        public string OptionC { get; init; }
        public string OptionD { get; init; }

        public char CorrectChoice { get; init; }
        public static MultipleChoiceQuestionDto ToMultipleChoiceQuestionDto(MultipleChoiceQuestion enity)
        {
            return new MultipleChoiceQuestionDto
            {
                Id = enity.Id,
                Title = enity.Title,
                Difficulty = enity.Difficulty,
                Mark = enity.Mark,
                OptionA = enity.OptionA,
                OptionB = enity.OptionB,
                OptionC = enity.OptionC,
                OptionD = enity.OptionD,
                CorrectChoice = enity.CorrectChoice,
            };
        }
        public static IEnumerable<MultipleChoiceQuestionDto> ToListOfMultiplChoicQuestionsDto(IEnumerable<MultipleChoiceQuestion> questions)
        {
            return questions.Select(question => ToMultipleChoiceQuestionDto(question));
        }
    }


}
