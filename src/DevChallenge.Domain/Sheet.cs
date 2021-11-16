using CSharpFunctionalExtensions;
using static CSharpFunctionalExtensions.Result;

namespace DevChallenge.Domain;

public class Sheet
{
    private Sheet(Millimeter width, Millimeter height)
    {
        Width = width;
        Height = height;
    }

    public Millimeter Width { get; }

    public Millimeter Height { get; }

    public Result<Sheet> CanPlace(Box box)
    {
        var canBePlacedHorizontaly = Width.Value >= box.TemplateWidth && Height.Value >= box.TemplateHeight;
        var canBePlacedVertically = Width.Value >= box.TemplateHeight && Height.Value >= box.TemplateWidth;
        return SuccessIf(canBePlacedHorizontaly || canBePlacedVertically, this, Messages.InvalidSheet.TooSmall);
    }

    public static Result<Sheet> Create(int width, int height)
    {
        var millimeterWidth = Millimeter.Create(width);
        var millimeterHeight = Millimeter.Create(height);

        return FirstFailureOrSuccess(millimeterWidth, millimeterHeight)
            .Bind<Sheet>(() => new Sheet(millimeterWidth.Value, millimeterHeight.Value));
    }
}