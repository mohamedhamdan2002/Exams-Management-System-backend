using Application.DataTransferObjects.ExamDtos;
using Application.Services.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class ExamHub: Hub<IExamClient>
    {
        private readonly IServiceManager _services;

        public ExamHub(IServiceManager services)
        {
            _services = services;
        }

        public async Task CreateExam(Guid categoryId, ExamForCreationDto examForCreationDto)
        {
            var examDto = await _services.ExamService.CreateExamForCategoryAsync(categoryId, examForCreationDto);
            await Clients.All.ReciveExam(examDto);
        }
    }
}
