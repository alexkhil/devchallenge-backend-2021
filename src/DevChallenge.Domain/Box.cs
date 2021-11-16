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

    public IReadOnlyList<Command> CutHorizontaly(int x, int y) =>
        new List<Command>
        {
            new GotoCommand(x+Height, y),
            new DownCommand(),
            new GotoCommand(x+Height, y+Height),
            new GotoCommand(x, y+Height),
            new GotoCommand(x, y+Height+Depth),
            new GotoCommand(x+Height, y+Height+Depth),
            new GotoCommand(x+Height, y+2*Height+Depth),
            new GotoCommand(x+Height+Width, y+2*Height+Depth),
            new GotoCommand(x+Height+Width, y+Height+Depth),
            new GotoCommand(x+2*Height+2*Width, y+Height+Depth),
            new GotoCommand(x+2*Height+2*Width, y+Height),
            new GotoCommand(x+Height+Width, y+Height),
            new GotoCommand(x+Height+Width, y),
            new GotoCommand(x+Height, y),
            new UpCommand()
        };

    public IReadOnlyList<Command> CutVerticaly(int x, int y) =>
        new List<Command>
        {
            new GotoCommand(x+Height, y),
            new DownCommand(),
            new GotoCommand(x+Height, y+Height),
            new GotoCommand(x, y+Height),
            new GotoCommand(x, y+Height+Depth),
            new GotoCommand(x+Height, y+Height+Width),
            new GotoCommand(x+Height, y+2*Height+2*Width),
            new GotoCommand(x+Height+Depth, y+2*Height+2*Width),
            new GotoCommand(x+Height+Depth, y+Height+Width),
            new GotoCommand(x+2*Height+Depth, y+Height+Width),
            new GotoCommand(x+2*Height+Depth, y+Height),
            new GotoCommand(x+Height+Depth, y+Height),
            new GotoCommand(x+Height+Depth, y),
            new GotoCommand(x+Height, y),
            new UpCommand()
        };

    public static Result<Box> Create(int width, int height, int depth)
    {
        var millimeterWidth = Millimeter.Create(width);
        var millimeterHeight = Millimeter.Create(height);
        var millimeterDepth = Millimeter.Create(depth);

        return FirstFailureOrSuccess(millimeterWidth, millimeterHeight, millimeterDepth)
            .Bind<Box>(() => new Box(millimeterWidth.Value, millimeterHeight.Value, millimeterDepth.Value));
    }
}
