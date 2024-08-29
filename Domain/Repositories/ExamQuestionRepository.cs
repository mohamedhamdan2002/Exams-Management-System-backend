using Domain.Data;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    internal sealed class ExamQuestionRepository : RepositoryBase<ExamQuestion>, IExamQuestionRepository
    {
        public ExamQuestionRepository(AppDbContext context) : base(context) { }

        public void AddQuestionToExam(ExamQuestion examQuestion)
            => Create(examQuestion);
        public void RemoveQuestionFromExam(ExamQuestion examQuestion)
            => Delete(examQuestion);
        //public async Task<IEnumerable<KeyValuePair<Guid, Question>>> GetTFQuestionsForExam(Guid examId)
        //{
        //    return await _context.ExamQuestions
        //         .Where(q => q.ExamId == examId)
        //         .ToDictionaryAsync(x => x.QuestionId);
        //}
    }
}
