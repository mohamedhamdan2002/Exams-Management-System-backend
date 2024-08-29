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
    internal sealed class MultipleChoiceQuestionRepository : RepositoryBase<MultipleChoiceQuestion>, IMultipleChoiceQuestionRepository
    {
        public MultipleChoiceQuestionRepository(AppDbContext context)
            : base(context) { }

        public async Task<MultipleChoiceQuestion?> GetMultipleChoiceQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperties)
            => await GetByCondition(q => q.Id == id, trackChanges, includeProperties)
                    .SingleOrDefaultAsync();

        public async Task<IEnumerable<MultipleChoiceQuestion>> GetMultipleChoiceQuestionsAsync(bool trackChanges = false)
            => await GetAll(trackChanges)
                    .ToListAsync();

        public async Task<Dictionary<Guid, MultipleChoiceQuestion>> GetMCQuestionsForExam(Guid examId)
        {
            return await _context.Questions
                 .OfType<MultipleChoiceQuestion>()
                 .Where(q => q.Exams.Any(x => x.ExamId == examId))
                 .ToDictionaryAsync(x => x.Id);
        }
    }
}
