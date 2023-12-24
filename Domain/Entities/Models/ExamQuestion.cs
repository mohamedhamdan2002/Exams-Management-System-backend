using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class ExamQuestion
    {
        public Guid ExamId { get; set; }
        public Guid QuestionId { get; set; }
        public Exam? Exam { get; set; }
        public Question? Question { get; set; }
    }
}
