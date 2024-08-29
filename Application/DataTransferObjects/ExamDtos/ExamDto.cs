using Application.DataTransferObjects.QuestionDtos;
using Domain.Entities.Models;
using Domain.Enums;

namespace Application.DataTransferObjects.ExamDtos
{
    public record ExamDto
    {
        public Guid Id { get; init; }
        public string? Category{ get; init; }
        public Guid CategoryId { get; init; }
        public string? Title { get; init; }
        public TimeSpan Duration { get; init; }
        public DateOnly Date { get; init; }
        public decimal TotalMarks { get; init; }
        public string Term { get; init; }
        public string Level { get; init; }
        public List<QuestionDto?>? Questions { get; init; }

        public static ExamDto ToExamDto(Exam entity)
        {
            return new ExamDto
            {
                Id = entity.Id,
                Category = entity.Category?.Name!,
                CategoryId = entity.CategoryId,
                Title = entity.Title,
                Term = entity.Term.ToString(),
                Duration = entity.Duration,
                Date = entity.Date,
                TotalMarks = entity.TotalMarks,
                Level = entity.Level.ToString(),
                Questions = entity.Questions.Select(q =>
                {
                    if (q.Question is MultipleChoiceQuestion)
                        return (QuestionDto) MultipleChoiceQuestionDto.ToMultipleChoiceQuestionDto(q.Question);
                    else if (q.Question is TrueAndFalseQuestion)
                        return (QuestionDto) TrueAndFalseQuestionDto.ToTrueAndFalseQuestionDto(q.Question);
                    else
                        return null;
                }).ToList(),
                    
            };
            
        }
        public static IEnumerable<ExamDto> ToListOfExamsDto(IEnumerable<Exam> exams)
        {
            return exams.Select(exam => ToExamDto(exam));
        }
    }
}
