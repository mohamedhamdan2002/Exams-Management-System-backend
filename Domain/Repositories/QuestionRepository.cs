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
    internal sealed class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {

        public QuestionRepository(AppDbContext context) 
            : base(context) { }
        public void CreateQuestion(Question question)
            => Create(question);
        public void DeleteQuestion(Question question)
            => Delete(question);
        public async Task<Question?> GetQuestionByIdAsync(Guid id, bool tarckChanges = false, params string[] includeProperties)
            => await GetByCondition(question => question.Id == id, tarckChanges, includeProperties).SingleOrDefaultAsync();

        public async Task<IEnumerable<Question>> GetQuestionsAsync(bool trackChanges = false)
            => await GetAll(trackChanges)
            .OrderBy(question => question.Title)
            .ToListAsync();
    }
}
