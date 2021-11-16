using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Domain;

namespace DevChallenge.Application.Integration.Cutter;

public class VerticalCutter : ICutter
{
    public CutResult Cut(Sheet sheet, Box template)
    {
        var commands = new List<Command>();
        var amount = 0;
        for (var y = 0; template.TemplateWidth <= sheet.Height - y; y += template.TemplateWidth)
        {
            for (var x = 0; template.TemplateHeight <= sheet.Width - x; x += template.TemplateHeight)
            {
                commands.AddRange(CutVertically(template, x, y));
                amount++;
            }
        }

        return new CutResult(amount, commands);
    }

    private static IReadOnlyList<Command> CutVertically(Box box, int x, int y)
    {
        return new List<Command>
        {
            new GotoCommand(x+box.Height, y),
            new DownCommand(),
            new GotoCommand(x+box.Height, y+box.Height),
            new GotoCommand(x, y+box.Height),
            new GotoCommand(x, y+box.Height+box.Depth),
            new GotoCommand(x+box.Height, y+box.Height+box.Width),
            new GotoCommand(x+box.Height, y+2*box.Height+2*box.Width),
            new GotoCommand(x+box.Height+box.Depth, y+2*box.Height+2*box.Width),
            new GotoCommand(x+box.Height+box.Depth, y+box.Height+box.Width),
            new GotoCommand(x+2*box.Height+box.Depth, y+box.Height+box.Width),
            new GotoCommand(x+2*box.Height+box.Depth, y+box.Height),
            new GotoCommand(x+box.Height+box.Depth, y+box.Height),
            new GotoCommand(x+box.Height+box.Depth, y),
            new GotoCommand(x+box.Height, y),
            new UpCommand()
        };
    }
}