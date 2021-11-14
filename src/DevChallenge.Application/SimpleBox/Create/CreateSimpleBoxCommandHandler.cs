using CSharpFunctionalExtensions;
using DevChallenge.Domain;
using MediatR;

namespace DevChallenge.Application.SimpleBox.Create;

public class CreateSimpleBoxCommandHandler : RequestHandler<CreateSimpleBoxCommand, Result<CreateSimpleBoxResult>>
{
    protected override Result<CreateSimpleBoxResult> Handle(CreateSimpleBoxCommand request) =>
        Box.Create(request.BoxSize.Width, request.BoxSize.Height, request.BoxSize.Depth)
           .Bind(box => Sheet.Create(request.SheetSize.Width, request.SheetSize.Length).Check(x => x.CanPlace(box)))
           .Map(x => new CreateSimpleBoxResult());
}
