using Book_Evaluation_Management_System.API.Configuration;
using Book_Evaluation_Management_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDependencyInjection();

builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BookEvaluationManagement");

builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

