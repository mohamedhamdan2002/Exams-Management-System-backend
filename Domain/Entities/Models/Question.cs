using Domain.Enums;

namespace Domain.Entities.Models
{
    public abstract class Question : BaseEntity
    {
        public string Title { get; set; }
        public DifficultyEnum Difficulty { get; set; }
        public decimal Mark { get; set; }
        public ICollection<ExamQuestion> Exams { get; set; } = new List<ExamQuestion>();
    }
}
