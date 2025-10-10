using Leadership.Domain.IRepositories;
using Leadership.Domain.IServices;
using Leadership.Repositories.Data;
using Leadership.Repositories.RepositoryImpl;
using Leadership.Service.ServiceImpl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IQuizRepository,QuizRepository>();

builder.Services.AddDbContext<LeaderBoardDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
