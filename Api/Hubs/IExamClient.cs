using Application.DataTransferObjects.ExamDtos;

namespace Api.Hubs
{
    public interface IExamClient
    {
        Task ReciveExam(ExamDto examDto);
    }
}
