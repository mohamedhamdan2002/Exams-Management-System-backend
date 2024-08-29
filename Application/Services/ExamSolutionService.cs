using Application.DataTransferObjects.ExamDtos;
using Application.DataTransferObjects.ExamSolutionDtos;
using Application.Services.Contracts;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal sealed class ExamSolutionService : IExamSolutionService
    {
        private readonly IRepositoryManager _repository;

        public ExamSolutionService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task CreateExamSolution(string userId, Guid examId, SolutionForCreationDto solution)
        {
            await CheckIfExamExistAsync(examId);
            var examSolution = new ExamSolution();
            var marks = 0m;
            var mcqQuestions = await _repository.MultipleChoiceQuestionRepository.GetMCQuestionsForExam(examId);
            var tfQuestions = await _repository.TrueAndFalseQuestionRepository.GetTFQuestionsForExam(examId);
            if (solution.Answers.Any())
            {
                foreach (var answer in solution.Answers)
                {

                    switch (answer.Type)
                    {
                        case "Choice":
                            var choiceAnswer = answer as ChoiceAnswerDto;
                            if (choiceAnswer is null || !mcqQuestions.ContainsKey(choiceAnswer.QuestionId))
                                break;
                            var questionId = choiceAnswer.QuestionId;
                            if (mcqQuestions[questionId].CorrectChoice == choiceAnswer.Choice)
                                marks += mcqQuestions[questionId].Mark;
                            var choice = new ChoiceAnswer
                            {

                                Choice = choiceAnswer.Choice!,
                                QuestionId = questionId
                            };
                            examSolution.Answers.Add(choice);
                            break;
                        case "Boolean":
                            var booleanAnswer = answer as BooleanAnswerDto;
                            if (booleanAnswer is null || !tfQuestions.ContainsKey(booleanAnswer.QuestionId))
                                break;
                            var tfquestionId = booleanAnswer.QuestionId;
                            if (tfQuestions[tfquestionId].CorrectAnswer == booleanAnswer.Value)
                                marks += tfQuestions[tfquestionId].Mark;
                            var boolean = new BooleanAnswer
                            {

                                Value = booleanAnswer.Value,
                                QuestionId = tfquestionId
                            };
                            examSolution.Answers.Add(boolean);
                            break;
                    }
                }
            }
            examSolution.TotalMarks = marks;
            _repository.ExamSolutionRepository.CreateExamSolutionForExam(userId, examId, examSolution);
            await _repository.SaveAsync();
        }

        public async Task<ExamResultDto> GetExamSolutionForUser(string userId, Guid examId)
        {
            await CheckIfExamExistAsync(examId);
            var examResult = await _repository.ExamSolutionRepository
                    .GetExamResult(
                        userId: userId,
                        examId: examId,
                        selector: x => new ExamResultDto
                        {
                            ExamId = x.ExamId,
                            CategoryName = x.Exam.Category.Name,
                            Title = x.Exam.Title,
                            Date = x.Exam.Date,
                            Duration = x.Exam.Duration,
                            Level = x.Exam.Level.ToString(),
                            Term = x.Exam.Term.ToString(),
                            TotalMarks = x.Exam.TotalMarks,
                            QuestionsResult = x.Answers.Select(ans => Cast(ans)).ToList(),
                            marks = x.TotalMarks
                        },
                        trackChanges: false,
                        "Answers.Question",
                        "Exam"
                     );
            return examResult!;
        }

        private async Task CheckIfExamExistAsync(Guid examId)
        {
            if (!await _repository.ExamRepository.CheckIfExamExistAsync(examId))
                throw new Exception();
        }
        private static QuestionAnswerResultDto Cast(Answer answer)
        {
            if (answer is BooleanAnswer)
                return (QuestionAnswerResultDto)ToBooleanDto(answer);
            else if (answer is ChoiceAnswer)
                return (QuestionAnswerResultDto)ToChoiceDto(answer);
            else 
                return null!;
        }
        private static QuestionAnswerResultDto ToChoiceDto(Answer answer)
        {
            var choiceAnswer = answer as ChoiceAnswer;
            var mcQuestion = (MultipleChoiceQuestion)choiceAnswer!.Question;
            return new MCQuestionAnswerResultDto
            {
                QuestionId = choiceAnswer!.QuestionId,
                Title = mcQuestion.Title,
                OptionA = mcQuestion.OptionA,
                OptionB = mcQuestion.OptionB,
                OptionC = mcQuestion.OptionC,
                OptionD = mcQuestion.OptionD,
                Mark = mcQuestion.Mark,
                CorrectChoice = mcQuestion.CorrectChoice,
                Choice = choiceAnswer!.Choice,
            };
        }
        private static QuestionAnswerResultDto ToBooleanDto(Answer answer)
        {
            var booleanAnswer = answer as BooleanAnswer;
            var tfQuestion = (TrueAndFalseQuestion) booleanAnswer!.Question;
            return new TFQuestionAnswerResultDto
            {
                QuestionId = booleanAnswer!.QuestionId,
                Title = tfQuestion.Title,
                CorrectAnswer = tfQuestion.CorrectAnswer,
                Mark = tfQuestion.Mark,
                Answer = booleanAnswer!.Value            
            };
        }
    }
}
