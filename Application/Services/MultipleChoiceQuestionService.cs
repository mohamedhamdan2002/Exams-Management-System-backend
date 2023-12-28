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
    internal sealed class MultipleChoiceQuestionService : IMultipleChoiceQuestionService
    {
        private readonly IRepositoryManager _repository;

        public MultipleChoiceQuestionService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<QuestionDto> CreateMultipleChoiceQuestionAsync(MultipleChoiceQuestionForCreationDto questionForCreationDto)
        {
            MultipleChoiceQuestion newQuestion = MultipleChoiceQuestionForCreationDto.ToMultipleChoiceQuestion(questionForCreationDto);
            _repository.MultipleChoiceQuestionRepository.CreateMultipleChoiceQuestion(newQuestion);
            await _repository.SaveAsync();
            return MultipleChoiceQuestionDto.ToMultipleChoiceQuestionDto(newQuestion);
        }

        public async Task DeleteMultipleChoiceQuestionAsync(Guid id, bool trackChanges = false)
        {
            MultipleChoiceQuestion question = await getMultipleChoiceQuestionAndCheckIfItExistAsync(id, trackChanges);
            _repository.MultipleChoiceQuestionRepository.DeleteMultipleChoiceQuestion(question);
            await _repository.SaveAsync();
        }

        public async Task<MultipleChoiceQuestionDto> GetMultipleChoiceQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            MultipleChoiceQuestion question = await getMultipleChoiceQuestionAndCheckIfItExistAsync(id, trackChanges);
            return MultipleChoiceQuestionDto.ToMultipleChoiceQuestionDto(question);
        }

        public async Task<IEnumerable<MultipleChoiceQuestionDto>> GetMultipleChoiceQuestionsAsync(bool trackChanges = false)
        {
            IEnumerable<MultipleChoiceQuestion> questions = await _repository.MultipleChoiceQuestionRepository.GetMultipleChoiceQuestionsAsync(trackChanges);
            return MultipleChoiceQuestionDto.ToListOfMultiplChoicQuestionsDto(questions);
        }

        public async Task UpdateMultipleChoiceQuestionAsync(Guid id, MultipleChoiceQuestionForUpdateDto questionForUpdateDto, bool trackChanges = false)
        {
            MultipleChoiceQuestion question = await getMultipleChoiceQuestionAndCheckIfItExistAsync(id, trackChanges);
            MultipleChoiceQuestionForUpdateDto.UpdateMultipleChoiceQuestion(questionForUpdateDto, question);
            await _repository.SaveAsync();
        }

        private async Task<MultipleChoiceQuestion> getMultipleChoiceQuestionAndCheckIfItExistAsync(Guid id, bool trackChanges)
        {
            MultipleChoiceQuestion question = await _repository.MultipleChoiceQuestionRepository.GetMultipleChoiceQuestionByIdAsync(id, trackChanges) ?? throw new Exception();
            return question;
        }
    }
}
