using Application.DataTransferObjects.ExamDtos;
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
    internal sealed class ExamService : IExamService
    {
        private readonly IRepositoryManager _repository;

        public ExamService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<ExamDto> CreateExamForCategoryAsync(Guid categoryId, ExamForCreationDto examForCreationDto)
        {
            Exam newExamEntity = ExamForCreationDto.ToExam(examForCreationDto);
            _repository.ExamRepository.CreateExamForCategory(categoryId, newExamEntity);
            await _repository.SaveAsync();
            ExamDto examDtoToReturn = ExamDto.ToExamDto(newExamEntity);
            return examDtoToReturn;
        }

        public async Task DeleteExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false)
        {
            await checkIfCategoryExist(categoryId, trackChanges);
            Exam examToDelete = await getExamAndCheckIfItExistAsync(categoryId, id, trackChanges);
            _repository.ExamRepository.DeleteExam(examToDelete);
            await _repository.SaveAsync();
        }

        private async Task<Exam> getExamAndCheckIfItExistAsync(Guid categoryId, Guid id, bool trackChanges)
        {
            Exam exam = await _repository.ExamRepository.GetExamForCatogoryAsync(categoryId, id, trackChanges) ?? throw new Exception();
            return exam;
        }

        public async Task<ExamDto> GetExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            await checkIfCategoryExist(categoryId, trackChanges);
            Exam examEntity = await getExamAndCheckIfItExistAsync(categoryId, id, trackChanges);
            ExamDto examDtoToReturn = ExamDto.ToExamDto(examEntity);
            return examDtoToReturn;
        }

        public async Task<IEnumerable<ExamDto>> GetExamsForCategoryAsync(Guid categoryId, bool trackChanges = false)
        {
            await checkIfCategoryExist(categoryId, trackChanges);
            IEnumerable<Exam> exams = await _repository.ExamRepository.GetExamsForCategoryAsync(categoryId, trackChanges);
            return ExamDto.ToListOfExamsDto(exams);
        }

        public async Task UpdageExamForCategoryAsync(Guid categoryId, Guid id, ExamForUpdateDto examForUpdateDto, bool trackChanges = false)
        {
            await checkIfCategoryExist(categoryId, trackChanges);
            Exam examToUpdate = await getExamAndCheckIfItExistAsync(categoryId, id, trackChanges);
            ExamForUpdateDto.UpdateExam(examForUpdateDto, examToUpdate);
            await _repository.SaveAsync();
        }

        private async Task checkIfCategoryExist(Guid categoryId, bool trackChanges)
        {
            _ = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges)
                ?? throw new Exception();
        }

       
    }
}
