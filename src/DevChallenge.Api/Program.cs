using DevChallenge.Api.Endpoints;
using DevChallenge.Application.SimpleBox.Create;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(CreateSimpleBoxCommand));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI();
app.UseEndpointDefinitions();

app.Run();