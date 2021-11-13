using FluentValidation;
using System.Text.Json.Serialization;

namespace DevChallenge.Api;

public record SimpleBoxRequest(SheetSize SheetSize, BoxSize BoxSize);

public record BoxSize(
    [property: JsonPropertyName("w")] int Width,
    [property: JsonPropertyName("d")] int Depth,
    [property: JsonPropertyName("h")] int Height);

public record SheetSize(
    [property: JsonPropertyName("w")] int Width,
    [property: JsonPropertyName("l")] int Length);

public class SimpleBoxRequestValidtor : AbstractValidator<SimpleBoxRequest>
{
    public SimpleBoxRequestValidtor()
    {
        RuleFor(x => x.BoxSize).NotNull().SetValidator(new BoxSizeValidator());
        RuleFor(x => x.SheetSize).NotNull().SetValidator(new SheetSizeValidator());
    }
}

public class BoxSizeValidator : AbstractValidator<BoxSize>
{
    public BoxSizeValidator()
    {
        RuleFor(x => x.Width).GreaterThan(0);
        RuleFor(x => x.Height).GreaterThan(0);
        RuleFor(x => x.Depth).GreaterThan(0);
    }
}

public class SheetSizeValidator : AbstractValidator<SheetSize>
{
    public SheetSizeValidator()
    {
        RuleFor(x => x.Width).GreaterThan(0);
        RuleFor(x => x.Length).GreaterThan(0);
    }
}