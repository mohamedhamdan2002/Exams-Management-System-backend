using Application.DataTransferObjects.ExamDtos;
using Application.DataTransferObjects.QuestionDtos;
using Domain.Enums;
using System.Text.Json.Serialization;

namespace Application.DataTransferObjects.ExamSolutionDtos
{
    public record ExamResultDto
    {
        public Guid ExamId { get; init; }
        public string CategoryName { get; init; }
        public string? Title { get; init; }
        public TimeSpan Duration { get; init; }
        public DateOnly Date { get; init; }
        public decimal TotalMarks { get; init; }
        public string Term { get; init; }
        public string Level { get; init; }
        public decimal marks { get; init; } 
        public List<QuestionAnswerResultDto> QuestionsResult { get; init; }
    }
    [JsonDerivedType(typeof(MCQuestionAnswerResultDto), typeDiscriminator: nameof(MCQuestionAnswerResultDto))]
    [JsonDerivedType(typeof(TFQuestionAnswerResultDto), typeDiscriminator: nameof(TFQuestionAnswerResultDto))]
    public abstract record QuestionAnswerResultDto
    {
        public Guid QuestionId { get; init; }
        public string Title { get; init; }
        public decimal Mark { get; init; }
    }
    public record MCQuestionAnswerResultDto : QuestionAnswerResultDto
    {
        public string OptionA { get; init; }
        public string OptionB { get; init; }
        public string OptionC { get; init; }
        public string OptionD { get; init; }
        public string CorrectChoice { get; init; }
        public string Choice { get; init; }
    }
    public record TFQuestionAnswerResultDto : QuestionAnswerResultDto
    {
        public bool CorrectAnswer { get; init; }
        public bool Answer { get; init; }
    }
}
