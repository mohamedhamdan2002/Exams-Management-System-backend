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

        public void CreateTrueAndFalseQuestion(TrueAndFalseQuestion question)
            => Create(question);

        public void DeleteTrueAndFalseQuestion(TrueAndFalseQuestion question)
            => Delete(question);
        public async Task<TrueAndFalseQuestion?> GetTrueAndFalseQuestionByIdAsync(Guid id, bool tarckChanges = false, params string[] includeProperties)
            => await GetByCondition(question => question.Id == id, tarckChanges, includeProperties).SingleOrDefaultAsync();
        public async Task<IEnumerable<TrueAndFalseQuestion>> GetTrueAndFalseQuestionsAsync(bool trackChanges = false)
            => await GetAll(trackChanges)
            .OrderBy(question => question.Title)
            .ToListAsync();
    }
}
