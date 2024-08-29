using Domain.Enums;

namespace Domain.Entities.Models
{
    public class Exam : BaseEntity
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public DateOnly Date { get; set; }
        public decimal TotalMarks { get; set; }
        public TermEnum Term { get; set; }
        public LevelEnum Level { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ExamQuestion> Questions { get; set; } = new List<ExamQuestion>();
        public ICollection<ExamSolution> Solutions { get; set; } = new List<ExamSolution>();
    }

}
