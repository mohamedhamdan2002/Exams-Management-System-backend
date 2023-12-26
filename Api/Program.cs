using Api.Extensions;
using Application.Services;
using Application.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureEfCore(builder.Configuration);
builder.Services.ConfigureIRepositoryManager();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.ConfigureIServiceManager();
//builder.Services.SetAllRequiredConfigurations(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
