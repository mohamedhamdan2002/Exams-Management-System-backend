using Domain.Entities.Models;

namespace Application.DataTransferObjects.ExamDtos
{
    public record ExamForCreationDto : ExamForManipulationDto
    {
        public static Exam ToExam(ExamForCreationDto examForCreationDto)
        {
            return new Exam
            {
                Title = examForCreationDto.Title!,
                TotalMarks = examForCreationDto.TotalMarks!,
                Term = examForCreationDto.Term!,
                Date = examForCreationDto.Date!,
                Level = examForCreationDto.Level!,
                Duration = examForCreationDto.Duration!,
            };
        }
    }

}
