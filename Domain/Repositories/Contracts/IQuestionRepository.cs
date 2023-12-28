using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsAsync(bool trackChanges = false);
        Task<Question?> GetQuestionByIdAsync(Guid id,
            bool tarckChanges = false,
            params string[] includeProperties);
        void CreateQuestion(Question question);

        void DeleteQuestion(Question question);
    }
}
