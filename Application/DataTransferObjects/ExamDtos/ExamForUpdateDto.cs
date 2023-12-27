using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Application.DataTransferObjects.ExamDtos
{
    public record ExamForUpdateDto : ExamForManipulationDto
    {
        public static void UpdateExam(ExamForUpdateDto examForUpdateDto, Exam exam)
        {
            exam.Title = examForUpdateDto.Title!;
            exam.Duration = examForUpdateDto.Duration!;
            exam.Date = examForUpdateDto.Date!;
            exam.Level = examForUpdateDto.Level!;
            exam.Term = examForUpdateDto.Term!;
            exam.TotalMarks = examForUpdateDto.TotalMarks!;
        }
    }

}
