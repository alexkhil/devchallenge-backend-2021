using CSharpFunctionalExtensions;
using DevChallenge.Domain;
using MediatR;

namespace DevChallenge.Application.SimpleBox.Create;

public class CreateSimpleBoxCommandHandler : RequestHandler<CreateSimpleBoxCommand, Result<CreateSimpleBoxResult>>
{
    private readonly ICutter boxPacker;

    public CreateSimpleBoxCommandHandler(ICutter boxPacker)
    {
        this.boxPacker = boxPacker;
    }

    protected override Result<CreateSimpleBoxResult> Handle(CreateSimpleBoxCommand request)
    {
        var box = Box.Create(request.BoxSize.Width, request.BoxSize.Height, request.BoxSize.Depth);
        var sheet = Sheet.Create(request.SheetSize.Width, request.SheetSize.Length);

        return Result.FirstFailureOrSuccess(box, sheet)
            .Bind(() => sheet.Value.CanPlace(box.Value))
            .Map(x => boxPacker.Cut(x, box.Value))
            .Map(x => new CreateSimpleBoxResult(x.Amount, x.Commands));
    }
}
