using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record TrueAndFalseQuestionDto : QuestionDto
    {
        public bool CorrectAnswer { get; init; }

        public static TrueAndFalseQuestionDto ToTrueAndFalseQuestionDto(Question enity)
        {
            var trueAndFalseQuestion = enity as TrueAndFalseQuestion;
            return new TrueAndFalseQuestionDto
            {
                Id = trueAndFalseQuestion!.Id,
                Title = trueAndFalseQuestion.Title,
                Difficulty = trueAndFalseQuestion.Difficulty,
                Mark = trueAndFalseQuestion.Mark,
                CorrectAnswer = trueAndFalseQuestion.CorrectAnswer
            };
        }
        public static IEnumerable<TrueAndFalseQuestionDto> ToListOfTrueAndFalseQuestionsDto(IEnumerable<Question> questions)
        {
            return questions.Select(question => ToTrueAndFalseQuestionDto(question));
        }
    }



}
