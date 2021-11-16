using CSharpFunctionalExtensions;
using MediatR;

namespace DevChallenge.Application.SimpleBox.Create;

public record CreateSimpleBoxCommand(SheetSize SheetSize, BoxSize BoxSize) : IRequest<Result<CreateSimpleBoxResult>>;

public record BoxSize(int Width, int Depth, int Height);

public record SheetSize(int Width, int Length);