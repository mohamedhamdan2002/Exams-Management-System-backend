namespace Domain.Entities.Models
{
    public abstract class Answer : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
    public class ChoiceAnswer : Answer
    {
        public string Choice { get; set; }
    }
    public class BooleanAnswer : Answer
    {
        public bool Value { get; set; }
    }
}
