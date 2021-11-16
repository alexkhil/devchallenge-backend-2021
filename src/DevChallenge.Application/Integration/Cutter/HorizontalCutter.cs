using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Domain;

namespace DevChallenge.Application.Integration.Cutter;

public class HorizontalCutter : ICutter
{
    public CutResult Cut(Sheet sheet, Box template)
    {
        var commands = new List<Command>();
        var amount = 0;
        for (var y = 0; template.TemplateHeight <= sheet.Height - y; y += template.TemplateHeight)
        {
            for (var x = 0; template.TemplateWidth <= sheet.Width - x; x += template.TemplateWidth)
            {
                commands.AddRange(CutHorizontally(template, x, y));
                amount++;
            }
        }

        return new CutResult(amount, commands);
    }

    private static IReadOnlyList<Command> CutHorizontally(Box box, int x, int y) =>
        new List<Command>
        {
            new GotoCommand(x+box.Height, y),
            new DownCommand(),
            new GotoCommand(x+box.Height, y+box.Height),
            new GotoCommand(x, y+box.Height),
            new GotoCommand(x, y+box.Height+box.Depth),
            new GotoCommand(x+box.Height, y+box.Height+box.Depth),
            new GotoCommand(x+box.Height, y+2*box.Height+box.Depth),
            new GotoCommand(x+box.Height+box.Width, y+2*box.Height+box.Depth),
            new GotoCommand(x+box.Height+box.Width, y+box.Height+box.Depth),
            new GotoCommand(x+2*box.Height+2*box.Width, y+box.Height+box.Depth),
            new GotoCommand(x+2*box.Height+2*box.Width, y+box.Height),
            new GotoCommand(x+box.Height+box.Width, y+box.Height),
            new GotoCommand(x+box.Height+box.Width, y),
            new GotoCommand(x+box.Height, y),
            new UpCommand()
        };
}