using Api.Converters;
using Api.Extensions;
using Api.Hubs;
using Application.Utilities;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new AnswerDtoConverter());
});
builder.Services.SetAllRequiredConfigurations(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors(AppConstants.AppPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.MapHub<NotificationHub>("notification-hub");
app.MapHub<ExamHub>("api/exam-hub");
// TestInConsole();
app.Run();

void TestInConsole()
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var categoryId = new Guid("8e3551c9-eee2-41a3-6a1d-08dc06dedac7");
        var examId = new Guid("34fca573-2191-403d-eaa0-08dc06de8101");
        var exam = context.Exams
                        .Include("Questions.Question")
                        .FirstOrDefault(ex => ex.Id == examId && ex.CategoryId == categoryId);
        Console.WriteLine($"[{exam?.Id}] {exam?.Title}");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("      Questions   ");
        if (exam is not null && exam.Questions.Any())
        {
            foreach (var q in exam.Questions)
            {
                Console.WriteLine($"{q.Question?.Title}");
            }

        }
        else
        {
            Console.WriteLine("no Questions in this exam");
        }
    }
}
