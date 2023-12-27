using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public abstract class Answer : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }

    public class ChoiceAnswer : Answer
    {
        public char Choice { get; set; }
    }
    public class BooleanAnswer : Answer
    {
        public bool Value { get; set; }
    }


}
