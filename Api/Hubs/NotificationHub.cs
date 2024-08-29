using Application.DataTransferObjects.ExamDtos;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        public async Task SendNotification(ExamNotificationDto examNotification)
        {
            await Clients.All.onNewExamCreated(examNotification);
        }
    }
}
