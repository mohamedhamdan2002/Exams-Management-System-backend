using Domain.Data;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    internal sealed class TrueAndFalseQuestionRepository : RepositoryBase<TrueAndFalseQuestion>, ITrueAndFalseQuestionRepository
    {
        public TrueAndFalseQuestionRepository(AppDbContext context)
            : base(context) { }

        public async Task<TrueAndFalseQuestion?> GetTrueAndFalseQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperties)
            => await GetByCondition(q => q.Id == id, trackChanges, includeProperties)
                    .FirstOrDefaultAsync();
        public async Task<IEnumerable<TrueAndFalseQuestion>> GetTrueAndFalseQuestionsAsync(bool trackChanges = false)
            => await GetAll(trackChanges)
                    .ToListAsync();
        public async Task<bool> CheckIfItExistsByIdAsync(Guid id)
            => await CheckIfItExistByConditionAsync(q => q.Id == id);
        public async Task<Dictionary<Guid, TrueAndFalseQuestion>> GetTFQuestionsForExam(Guid examId)
        {
           return await _context.Questions
                .OfType<TrueAndFalseQuestion>()
                .Where(q => q.Exams.Any(x => x.ExamId == examId))
                .ToDictionaryAsync(x => x.Id);
        }

    }
}
