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
    internal sealed class TrueAndFalseQuestionService : ITrueAndFalseQuestionService
    {
        private readonly IRepositoryManager _repository;

        public TrueAndFalseQuestionService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<QuestionDto> CreateTrueAndFalseQuestionAsync(TrueAndFalseQuestionForCreationDto questionForCreationDto)
        {
            TrueAndFalseQuestion newQuestion = TrueAndFalseQuestionForCreationDto.ToTrueAndFalseQuestion(questionForCreationDto);
            _repository.TrueAndFalseQuestionRepository.CreateTrueAndFalseQuestion(newQuestion);
            await _repository.SaveAsync();
            return TrueAndFalseQuestionDto.ToTrueAndFalseQuestionDto(newQuestion);
        }
    
        public async Task DeleteTrueAndFalseQuestionAsync(Guid id, bool trackChanges = false)
        {
            TrueAndFalseQuestion question = await getTrueAndFalseQuestionAndCheckIfItExistAsync(id, trackChanges);
            _repository.TrueAndFalseQuestionRepository.DeleteTrueAndFalseQuestion(question);
            await _repository.SaveAsync();
        }

        public async Task<TrueAndFalseQuestionDto> GetTrueAndFalseQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            TrueAndFalseQuestion question = await getTrueAndFalseQuestionAndCheckIfItExistAsync(id, trackChanges);
            return TrueAndFalseQuestionDto.ToTrueAndFalseQuestionDto(question);
        }

        public async Task<IEnumerable<TrueAndFalseQuestionDto>> GetTrueAndFalseQuestionsAsync(bool trackChanges = false)
        {
            IEnumerable<TrueAndFalseQuestion> questions = await _repository.TrueAndFalseQuestionRepository.GetTrueAndFalseQuestionsAsync(trackChanges);
            return TrueAndFalseQuestionDto.ToListOfTrueAndFalseQuestionsDto(questions);
        }

        public async Task UpdateTrueAndFalseQuestionAsync(Guid id, TrueAndFalseQuestionForUpdateDto questionForUpdateDto, bool trackChanges = false)
        {
            TrueAndFalseQuestion question = await getTrueAndFalseQuestionAndCheckIfItExistAsync(id, trackChanges);
            TrueAndFalseQuestionForUpdateDto.UpdateTrueAndFalseQuestion(questionForUpdateDto, question);
            await _repository.SaveAsync();
        }

        private async Task<TrueAndFalseQuestion> getTrueAndFalseQuestionAndCheckIfItExistAsync(Guid id, bool trackChanges)
        {
            TrueAndFalseQuestion question = await _repository.TrueAndFalseQuestionRepository.GetTrueAndFalseQuestionByIdAsync(id, trackChanges) ?? throw new Exception();
            return question;
        }
    }
}
