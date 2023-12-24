using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public abstract class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public DifficultyEnum Difficulty { get; set; }
        public decimal Mark { get; set; }
        public ICollection<ExamQuestion> Exams { get; set; } = new List<ExamQuestion>();
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
