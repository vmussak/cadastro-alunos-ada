using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Application.UseCases;
using Ada.Aluno.Database;
using Ada.Aluno.Database.Repositories;
using Ada.Aluno.Presentation.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    //Global
    options.Filters.Add(typeof(MinhaExceptionFilter));
    options.Filters.Add(typeof(LoggingFilter));
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MinhaConexao>(x => new MinhaConexao(
    builder.Configuration.GetConnectionString("AdaAlunosDatabase")
));

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();

builder.Services.AddScoped<ICriarAlunoUseCase, CriarAlunoUseCase>();
builder.Services.AddScoped<IBuscarAlunosUseCase, BuscarAlunosUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    await next.Invoke();
});

app.MapControllers();

app.Run();



