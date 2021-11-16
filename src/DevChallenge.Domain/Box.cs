using CSharpFunctionalExtensions;
using static CSharpFunctionalExtensions.Result;

namespace DevChallenge.Domain;

public class Box
{
    private Box(Millimeter width, Millimeter height, Millimeter depth)
    {
        Width = width;
        Height = height;
        Depth = depth;

        TemplateWidth = Millimeter.Create(2 * Height.Value + 2 * Width.Value).Value;
        TemplateHeight = Millimeter.Create(2 * Height.Value + Depth.Value).Value;
    }

    public Millimeter Width { get; }

    public Millimeter Height { get; }

    public Millimeter Depth { get; }

    public Millimeter TemplateWidth { get; }

    public Millimeter TemplateHeight { get; }

    public static Result<Box> Create(int width, int height, int depth)
    {
        var millimeterWidth = Millimeter.Create(width);
        var millimeterHeight = Millimeter.Create(height);
        var millimeterDepth = Millimeter.Create(depth);

        return FirstFailureOrSuccess(millimeterWidth, millimeterHeight, millimeterDepth)
            .Bind<Box>(() => new Box(millimeterWidth.Value, millimeterHeight.Value, millimeterDepth.Value));
    }
}