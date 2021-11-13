using DevChallenge.Api;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(x =>
{
    x.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<SimpleBoxRequest>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/api/simple_box", PostSimpleBoxRequest)
   .Accepts<SimpleBoxRequest>(Application.Json)
   .Produces<SuccessResponse>(Status200OK, Application.Json)
   .Produces<FailResponse>(Status422UnprocessableEntity, Application.Json);

app.Run();

static IResult PostSimpleBoxRequest(IValidator<SimpleBoxRequest> validator, SimpleBoxRequest request)
{
    var validationResult = validator.Validate(request);
    return validationResult.IsValid
        ? Results.Ok(new SuccessResponse(1, new List<Command> { new Goto(2, 3) }))
        : Results.UnprocessableEntity(new FailResponse("Invalid input format. Please use only positive integers"));
}