using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record MultipleChoiceQuestionDto : QuestionDto
    {
        public string OptionA { get; init; }
        public string OptionB { get; init; }
        public string OptionC { get; init; }
        public string OptionD { get; init; }

        public string CorrectChoice { get; init; }
        public static MultipleChoiceQuestionDto ToMultipleChoiceQuestionDto(Question enity)
        {
            var multipleChoiceQuestion = enity as MultipleChoiceQuestion;
            return new MultipleChoiceQuestionDto
            {
                Id = multipleChoiceQuestion!.Id,
                Title = multipleChoiceQuestion.Title,
                Difficulty = multipleChoiceQuestion.Difficulty,
                Mark = multipleChoiceQuestion.Mark,
                OptionA = multipleChoiceQuestion.OptionA,
                OptionB = multipleChoiceQuestion.OptionB,
                OptionC = multipleChoiceQuestion.OptionC,
                OptionD = multipleChoiceQuestion.OptionD,
                CorrectChoice = multipleChoiceQuestion.CorrectChoice,
            };
        }
        public static IEnumerable<MultipleChoiceQuestionDto> ToListOfMultiplChoicQuestionsDto(IEnumerable<Question> questions)
        {
            return questions.Select(question => ToMultipleChoiceQuestionDto(question));
        }
    }


}
