using Application.DataTransferObjects.QuestionDtos;
using Application.Services.Contracts;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;

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
            _repository.MultipleChoiceQuestionRepository.Create(newQuestion);
            await _repository.SaveAsync();
            return MultipleChoiceQuestionDto.ToMultipleChoiceQuestionDto(newQuestion);
        }

        public async Task DeleteMultipleChoiceQuestionAsync(Guid id, bool trackChanges = false)
        {
            MultipleChoiceQuestion question = await GetMultipleChoiceQuestionAndCheckIfItExistAsync(id, trackChanges);
            _repository.MultipleChoiceQuestionRepository.Delete(question);
            await _repository.SaveAsync();
        }

        public async Task<MultipleChoiceQuestionDto> GetMultipleChoiceQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            MultipleChoiceQuestion question = await GetMultipleChoiceQuestionAndCheckIfItExistAsync(id, trackChanges);
            return MultipleChoiceQuestionDto.ToMultipleChoiceQuestionDto(question);
        }

        public async Task<IEnumerable<MultipleChoiceQuestionDto>> GetMultipleChoiceQuestionsAsync(bool trackChanges = false)
        {
            IEnumerable<MultipleChoiceQuestion> questions = await _repository.MultipleChoiceQuestionRepository.GetMultipleChoiceQuestionsAsync(trackChanges);
            return MultipleChoiceQuestionDto.ToListOfMultiplChoicQuestionsDto(questions);
        }

        public async Task UpdateMultipleChoiceQuestionAsync(Guid id, MultipleChoiceQuestionForUpdateDto questionForUpdateDto, bool trackChanges = false)
        {
            MultipleChoiceQuestion question = await GetMultipleChoiceQuestionAndCheckIfItExistAsync(id, trackChanges);
            MultipleChoiceQuestionForUpdateDto.UpdateMultipleChoiceQuestion(questionForUpdateDto, question);
            await _repository.SaveAsync();
        }

        private async Task<MultipleChoiceQuestion> GetMultipleChoiceQuestionAndCheckIfItExistAsync(Guid id, bool trackChanges)
        {
            MultipleChoiceQuestion question = await _repository.MultipleChoiceQuestionRepository.GetMultipleChoiceQuestionByIdAsync(id, trackChanges) ?? throw new Exception();
            return question;
        }
    }
}