using Itmo.ObjectOrientedProgramming.Lab5.Application;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Options;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructurePersistence()
    .AddPresentationHttp();

builder.Services.Configure<AdminSessionOptions>(
    builder.Configuration.GetSection("AdminSession"));

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();