namespace Domain.Entities.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
