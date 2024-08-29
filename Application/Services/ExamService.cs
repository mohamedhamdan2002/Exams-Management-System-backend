using Application.DataTransferObjects.ExamDtos;
using Application.Services.Contracts;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public sealed class ExamService : IExamService
    {
        private readonly IRepositoryManager _repository;

        public ExamService(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ExamDto>> GetExamsAsync(bool trackChanges = false)
        {
            IEnumerable<ExamDto> exams = await _repository.ExamRepository.GetExamsAsync(
                selector: x => new ExamDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryId = x.CategoryId,
                    Category = x.Category.Name,
                    Date = x.Date,
                    Level = x.Level.ToString(),
                    Duration = x.Duration,
                    Term = x.Term.ToString(),
                    TotalMarks = x.TotalMarks
                },
                trackChanges);
            return exams;
            //return ExamDto.ToListOfExamsDto(exams);
        }
        public async Task<ExamDto> CreateExamForCategoryAsync(Guid categoryId, ExamForCreationDto examForCreationDto)
        {
            Exam newExamEntity = ExamForCreationDto.ToExam(examForCreationDto);
            if(examForCreationDto.Questions is not null && examForCreationDto.Questions.Any())
            {
                foreach (var questionId in examForCreationDto.Questions)
                    newExamEntity.Questions.Add(new ExamQuestion
                    {
                        QuestionId = questionId
                    });
            }
            _repository.ExamRepository.CreateExamForCategory(categoryId, newExamEntity);
            await _repository.SaveAsync();
            ExamDto examDtoToReturn = ExamDto.ToExamDto(newExamEntity);
            return examDtoToReturn;
        }

        public async Task DeleteExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false)
        {
            await CheckIfCategoryExist(categoryId, trackChanges);
            Exam examToDelete = await GetExamAndCheckIfItExistAsync(exam => exam.Id == id && exam.CategoryId == categoryId, trackChanges);
            _repository.ExamRepository.DeleteExam(examToDelete);
            await _repository.SaveAsync();
        }

        private async Task<Exam> GetExamAndCheckIfItExistAsync(Expression<Func<Exam, bool>> predicate, bool trackChanges, params string[] includeProperities)
        {
            Exam exam = await _repository.ExamRepository.GetExamAsync(predicate, trackChanges, includeProperities) ?? throw new Exception();
            return exam;
        }

        public async Task<ExamDto> GetExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            await CheckIfCategoryExist(categoryId, trackChanges);
            Exam examEntity = await GetExamAndCheckIfItExistAsync(exam => exam.Id == id && exam.CategoryId == categoryId, trackChanges, includeProperites);
            ExamDto examDtoToReturn = ExamDto.ToExamDto(examEntity);
            return examDtoToReturn;
        }

        public async Task<IEnumerable<ExamDto>> GetExamsForCategoryAsync(Guid categoryId, bool trackChanges = false)
        {
            await CheckIfCategoryExist(categoryId, trackChanges);
            IEnumerable<Exam> exams = await _repository.ExamRepository.GetExamsForCategoryAsync(categoryId, trackChanges);
            return ExamDto.ToListOfExamsDto(exams);
        }

        public async Task UpdateExamForCategoryAsync(Guid categoryId, Guid id, ExamForUpdateDto examForUpdateDto, bool trackChanges = false)
        {
            await CheckIfCategoryExist(categoryId, trackChanges);
            Exam examToUpdate = await GetExamAndCheckIfItExistAsync(exam => exam.Id == id && exam.CategoryId == categoryId, trackChanges, includeProperities: "Questions");

            ExamForUpdateDto.UpdateExam(examForUpdateDto, examToUpdate);
            if(examForUpdateDto.Questions != null && examForUpdateDto.Questions.Any())
            {
                examToUpdate.Questions = examForUpdateDto.Questions.Select(x => new ExamQuestion
                {
                    QuestionId = x,
                    ExamId = id
                }).ToList();
            }

            await _repository.SaveAsync();
        }

        private async Task CheckIfCategoryExist(Guid categoryId, bool trackChanges)
        {
            _ = await _repository.CategoryRepository.GetCategoryByIdAsync(categoryId, trackChanges)
                ?? throw new Exception();
        }

        public async Task<ExamDto> GetExamByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites)
        {
            Exam examEntity = await GetExamAndCheckIfItExistAsync(exam => exam.Id == id, trackChanges, includeProperites);
            ExamDto examDtoToReturn = ExamDto.ToExamDto(examEntity);
            return examDtoToReturn;
        }
    }
}
