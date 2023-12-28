using Domain.Entities.Models;

namespace Application.DataTransferObjects.QuestionDtos
{
    public record TrueAndFalseQuestionDto : QuestionDto
    {
        public bool CorrectAnswer { get; init; }

        public static TrueAndFalseQuestionDto ToTrueAndFalseQuestionDto(TrueAndFalseQuestion enity)
        {
            return new TrueAndFalseQuestionDto
            {
                Id = enity.Id,
                Title = enity.Title,
                Difficulty = enity.Difficulty,
                Mark = enity.Mark,
                CorrectAnswer = enity.CorrectAnswer
            };
        }
        public static IEnumerable<TrueAndFalseQuestionDto> ToListOfTrueAndFalseQuestionsDto(IEnumerable<TrueAndFalseQuestion> questions)
        {
            return questions.Select(question => ToTrueAndFalseQuestionDto(question));
        }
    }



}
