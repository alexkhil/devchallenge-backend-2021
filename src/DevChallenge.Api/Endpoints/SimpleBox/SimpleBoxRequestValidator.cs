using FluentValidation;

namespace DevChallenge.Api.Endpoints.SimpleBox;

public class SimpleBoxRequestValidator : AbstractValidator<SimpleBoxRequest>
{
    public SimpleBoxRequestValidator()
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
