using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class ExamSolution : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal TotalMarks { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
