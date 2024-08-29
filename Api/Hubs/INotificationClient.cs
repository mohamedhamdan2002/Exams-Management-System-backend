using Application.DataTransferObjects.ExamDtos;

namespace Api.Hubs
{
    public interface INotificationClient
    {
        Task onNewExamCreated(ExamNotificationDto examNotification);
    }
}
