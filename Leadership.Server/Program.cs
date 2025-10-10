using Leadership.Domain.IRepositories;
using Leadership.Domain.IServices;
using Leadership.Repositories.Data;
using Leadership.Repositories.RepositoryImpl;
using Leadership.Service.ServiceImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IQuizRepository,QuizRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

builder.Services.AddDbContext<LeaderBoardDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
//confige serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1",new OpenApiInfo
    {
       Title="Leadership API",
        Version="v1"
    });
});

//allow cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","Leadership API v1");
        c.RoutePrefix=string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAll");
try
{
    Log.Information("Leadership Service running");
    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Leadership Service failed to start");
}
finally
{
    Log.CloseAndFlush();
}