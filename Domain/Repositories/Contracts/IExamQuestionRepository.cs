using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IExamQuestionRepository
    {
        void AddQuestionToExam(ExamQuestion examQuestion);
        void RemoveQuestionFromExam(ExamQuestion examQuestion);

    }
}
