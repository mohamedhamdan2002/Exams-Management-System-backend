using Application.DataTransferObjects.ExamDtos;
using Application.DataTransferObjects.IDs;
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
    internal sealed class ExamQuestionService : IExamQuestionService
    {
        private readonly IRepositoryManager _repository;
        public ExamQuestionService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task AddQuestionToExam(Guid examId, Guid questionId)
        {
            await checkAndAssignQuestionToExam(examId, questionId);
            await _repository.SaveAsync();
        }

        private async Task checkIfQuestionExist(Guid questionId)
        {
            //_ = await _repository.QuestionRepository.GetQuestionByIdAsync(questionId)
            //    ?? throw new Exception();
        }

        private async Task checkIfExamExistAsync(Guid examId)
        {
            if(! await _repository.ExamRepository.CheckIfExamExistAsync(examId))
                throw new Exception();
        }

        public async Task AddQuestionsToExam(Guid examId, IEnumerable<QuestionIdDto> questionIds)
        {
            foreach (var questionId in questionIds)
            {
                try
                {
                    await checkAndAssignQuestionToExam(examId, questionId.Value);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            await _repository.SaveAsync();
        }

        private async Task checkAndAssignQuestionToExam(Guid examId, Guid questionId)
        {
            await checkIfExamExistAsync(examId);
            await checkIfQuestionExist(questionId);
            _repository.ExamQuestionRepository.AddQuestionToExam(new ExamQuestion
            {
                ExamId = examId,
                QuestionId = questionId
            });
        }

        public Task<ExamDto> GetExamByIdWithQuestionsAsync(Guid examId)
        {
            throw new NotImplementedException();   
        }
        
    }
}
