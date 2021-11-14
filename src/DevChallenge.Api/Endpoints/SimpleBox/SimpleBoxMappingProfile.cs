using AutoMapper;
using CSharpFunctionalExtensions;
using DevChallenge.Application.SimpleBox.Create;

namespace DevChallenge.Api.Endpoints.SimpleBox;

public class SimpleBoxMappingProfile : Profile
{
    public SimpleBoxMappingProfile()
    {
        CreateMap<SheetSize, Application.SimpleBox.Create.SheetSize>(MemberList.Destination);
        CreateMap<BoxSize, Application.SimpleBox.Create.BoxSize>(MemberList.Destination);
        CreateMap<SimpleBoxRequest, CreateSimpleBoxCommand>(MemberList.Destination);

        CreateMap<Result<CreateSimpleBoxResult>, SimpleBoxResponse>()
            .ConstructUsing((r) => r.IsFailure ? new FailResponse(r.Error) : new SuccessResponse(1, new List<Command>()));
    }
}