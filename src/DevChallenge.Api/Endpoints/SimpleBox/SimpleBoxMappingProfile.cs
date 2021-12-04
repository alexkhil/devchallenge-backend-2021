using AutoMapper;
using CSharpFunctionalExtensions;
using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Application.SimpleBox.Create;

namespace DevChallenge.Api.Endpoints.SimpleBox;

public class SimpleBoxMappingProfile : Profile
{
    public SimpleBoxMappingProfile()
    {
        CreateMap<SheetSize, Application.SimpleBox.Create.SheetSize>(MemberList.Destination);
        CreateMap<BoxSize, Application.SimpleBox.Create.BoxSize>(MemberList.Destination);
        CreateMap<SimpleBoxRequest, CreateSimpleBoxCommand>(MemberList.Destination);

        CreateMap<StartCommand, Dictionary<string, object>>(MemberList.None)
            .ConstructUsing(src => new Dictionary<string, object> { { "command", "START" } });

        CreateMap<StopCommand, Dictionary<string, object>>(MemberList.None)
            .ConstructUsing(src => new Dictionary<string, object> { { "command", "STOP" } });

        CreateMap<DownCommand, Dictionary<string, object>>(MemberList.None)
            .ConstructUsing(src => new Dictionary<string, object> { { "command", "DOWN" } });

        CreateMap<UpCommand, Dictionary<string, object>>(MemberList.None)
            .ConstructUsing(src => new Dictionary<string, object> { { "command", "UP" } });

        CreateMap<GotoCommand, Dictionary<string, object>>(MemberList.None)
            .ConstructUsing(src => new Dictionary<string, object>
            {
                { "command", "GOTO" },
                { "x", src.X },
                { "y", src.Y }
            });

        CreateMap<Result<CreateSimpleBoxResult>, SimpleBoxResponse>(MemberList.None)
            .ConstructUsing((src, ctx) =>
            {
                return src.IsSuccess
                    ? new SuccessResponse(src.Value.Amount, src.Value.Commands.Select(c => ctx.Mapper.Map<Dictionary<string, object>>(c)).ToList())
                    : new FailResponse(src.Error);
            });
    }
}