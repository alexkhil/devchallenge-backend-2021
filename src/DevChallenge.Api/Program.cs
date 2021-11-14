using DevChallenge.Api.Endpoints;
using DevChallenge.Api.Endpoints.SimpleBox;
using DevChallenge.Application.SimpleBox.Create;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(x => x.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<SimpleBoxRequest>());
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(typeof(CreateSimpleBoxCommand));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseEndpointDefinitions();

app.Run();