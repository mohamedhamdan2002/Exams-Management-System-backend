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

        public void CreateMultipleChoiceQuestion(MultipleChoiceQuestion question)
            => Create(question);
        public void DeleteMultipleChoiceQuestion(MultipleChoiceQuestion question)
            => Delete(question);
        public async Task<MultipleChoiceQuestion?> GetMultipleChoiceQuestionByIdAsync(Guid id, bool tarckChanges = false, params string[] includeProperties)
            => await GetByCondition(quetion => quetion.Id == id, tarckChanges, includeProperties).SingleOrDefaultAsync();


        public async Task<IEnumerable<MultipleChoiceQuestion>> GetMultipleChoiceQuestionsAsync(bool trackChanges = false)
            => await GetAll(trackChanges)
            .OrderBy(question => question.Title)
            .ToListAsync();
    }
}
