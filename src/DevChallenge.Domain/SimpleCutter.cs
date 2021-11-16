namespace DevChallenge.Domain;

public class SimpleCutter : ICutter
{
    public (int Amount, IReadOnlyList<Command> Commands) Cut(Sheet sheet, Box template)
    {
        var commands = new List<Command> { new StartCommand() };

        var (cutHorizonaly, horizontalBoxes) = CutBoxHorizontally(sheet, template);
        var (cutVerticaly, verticalBoxes) = CutBoxVertically(sheet, template);

        if (horizontalBoxes > verticalBoxes)
        {
            commands.AddRange(cutHorizonaly);
        }
        else
        {
            commands.AddRange(cutVerticaly);
        }

        commands.Add(new StopCommand());

        return (Math.Max(horizontalBoxes, verticalBoxes), commands);
    }

    // TODO: fix vertical cutter
    private static (List<Command> commands, int boxesCount) CutBoxVertically(Sheet sheet, Box template)
    {
        var commands = new List<Command>();
        var boxesCount = 0;
        for (var y = 0; template.TemplateWidth <= sheet.Height - y; y += template.TemplateHeight)
        {
            for (var x = 0; template.TemplateHeight <= sheet.Width - x; x += template.TemplateWidth)
            {
                commands.AddRange(template.CutVerticaly(x, y));
                boxesCount++;
            }
        }

        return (commands, boxesCount);
    }

    private static (List<Command> commands, int boxesCount) CutBoxHorizontally(Sheet sheet, Box template)
    {
        var commands = new List<Command>();
        var boxesCount = 0;
        for (var y = 0; template.TemplateHeight <= sheet.Height - y; y += template.TemplateHeight)
        {
            for (var x = 0; template.TemplateWidth <= sheet.Width - x; x += template.TemplateWidth)
            {
                commands.AddRange(template.CutHorizontaly(x, y));
                boxesCount++;
            }
        }

        return (commands, boxesCount);
    }
}