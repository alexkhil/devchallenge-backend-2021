using CSharpFunctionalExtensions;
using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Domain;
using MediatR;

namespace DevChallenge.Application.SimpleBox.Create;

public class CreateSimpleBoxCommandHandler : RequestHandler<CreateSimpleBoxCommand, Result<CreateSimpleBoxResult>>
{
    private readonly ICutter _cutter;

    public CreateSimpleBoxCommandHandler(ICutter cutter)
    {
        _cutter = cutter;
    }

    protected override Result<CreateSimpleBoxResult> Handle(CreateSimpleBoxCommand request)
    {
        var box = Box.Create(request.BoxSize.Width, request.BoxSize.Height, request.BoxSize.Depth);
        var sheet = Sheet.Create(request.SheetSize.Width, request.SheetSize.Length);

        return Result.FirstFailureOrSuccess(box, sheet)
            .Bind(() => sheet.Value.CanPlace(box.Value))
            .Map(x => _cutter.Cut(x, box.Value))
            .Map(x => new CreateSimpleBoxResult(x.Amount, x.Commands));
    }
}