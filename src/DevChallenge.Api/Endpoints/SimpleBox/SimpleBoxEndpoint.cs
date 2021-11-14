using AutoMapper;
using DevChallenge.Application.SimpleBox.Create;
using DevChallenge.Domain;
using MediatR;
using System.Net.Mime;

using static Microsoft.AspNetCore.Http.StatusCodes;

namespace DevChallenge.Api.Endpoints.SimpleBox;

public class SimpleBoxEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapPost("/api/simple_box", PostSimpleBoxRequest)
           .Accepts<SimpleBoxRequest>(MediaTypeNames.Application.Json)
           .Produces<SuccessResponse>(Status200OK, MediaTypeNames.Application.Json)
           .Produces<FailResponse>(Status422UnprocessableEntity, MediaTypeNames.Application.Json);
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IBoxPacker, RowBoxPacker>();
    }

    internal static async Task<IResult> PostSimpleBoxRequest(
        IMapper mapper,
        ISender sender,
        SimpleBoxRequest request,
        CancellationToken ct)
    {
        var command = mapper.Map<CreateSimpleBoxCommand>(request);
        var result = await sender.Send(command, ct);
        var response = mapper.Map<SimpleBoxResponse>(result);

        return response.Success ? Results.Ok(response) : Results.UnprocessableEntity(response);
    }
}
