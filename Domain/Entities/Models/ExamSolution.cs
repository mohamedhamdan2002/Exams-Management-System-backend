namespace Domain.Entities.Models
{
    public class ExamSolution : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public decimal TotalMarks { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; } = null!;
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
