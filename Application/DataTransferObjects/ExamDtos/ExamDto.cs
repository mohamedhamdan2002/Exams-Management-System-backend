using Domain.Entities.Models;
using Domain.Enums;

namespace Application.DataTransferObjects.ExamDtos
{
    public record ExamDto
    {
        public Guid Id { get; init; }
        public string? Title { get; init; }
        public TimeSpan Duration { get; init; }
        public DateOnly Date { get; init; }
        public decimal TotalMarks { get; init; }
        public TermEnum Term { get; init; }
        public LevelEnum Level { get; init; }

        public static ExamDto ToExamDto(Exam entity)
        {
            return new ExamDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Term = entity.Term,
                Duration = entity.Duration,
                Date = entity.Date,
                TotalMarks = entity.TotalMarks,
                Level = entity.Level,
            };
        }
        public static IEnumerable<ExamDto> ToListOfExamsDto(IEnumerable<Exam> exams)
        {
            return exams.Select(exam => ToExamDto(exam));
        }
    }
}
