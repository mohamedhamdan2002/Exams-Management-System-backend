using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class NavigationPropertiesConstant
    {
        public const string Question = nameof(Question);
        public const string ExamQuestion = nameof(ExamQuestion);
        public const string Questions = nameof(Questions);
        public const string Exam = nameof(Exam);
        public const string QuestionsThenQuestion = $"{Questions}.{Question}"; 
        public const string Category = nameof(Category);
    }
}
