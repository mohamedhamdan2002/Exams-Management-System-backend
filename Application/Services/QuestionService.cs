using Application.DataTransferObjects.QuestionDtos;
using Application.Services.Contracts;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal sealed class QuestionService : IQuestionService
    {
        private readonly IRepositoryManager _repository;

        public QuestionService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public Task DeleteQuestionAsync(Guid id, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDto> GetQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionsAsync(bool trackChanges = false)
        {

            throw new NotImplementedException();
        }
    }
}
