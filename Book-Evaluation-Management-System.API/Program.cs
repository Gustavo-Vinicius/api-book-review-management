using Book_Evaluation_Management_System.API.Configuration;
using Book_Evaluation_Management_System.API.HostedService;
using Book_Evaluation_Management_System.Application.Queries.Book.GetBooks;
using Book_Evaluation_Management_System.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDependencyInjection();

builder.Services.AddMiddlewaresConfiguration();

builder.Services.AddSwaggerConfiguration();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBooksQuery).Assembly));

var connectionString = builder.Configuration.GetConnectionString("BookEvaluationManagement");

builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(connectionString));

builder.Services.AddHostedService<DataCleanupHostedService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

