using Application.DataTransferObjects.ExamSolutionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IExamSolutionService
    {
        Task CreateExamSolution(string userId, Guid examId, SolutionForCreationDto solution);
        Task<ExamResultDto> GetExamSolutionForUser(string userId, Guid examId);
    }
}
