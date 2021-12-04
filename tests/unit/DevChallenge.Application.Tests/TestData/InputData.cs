using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Domain;
using Xunit;

namespace DevChallenge.Application.Tests.TestData;

public class InputData : TheoryData<Sheet, Box, CutResult>
{
    public InputData()
    {
        HorizontalBox.Union(VerticalBox).ToList()
            .ForEach(x => AddRow(x[0], x[1], x[2]));
    }
    
    public static TheoryData<Sheet, Box, CutResult> HorizontalBox =>
        new()
        {
            { Sheet.Create(4, 3).Value, Box.Create(1, 1, 1).Value, new CutResult(1, new Command[]
            {
                new GotoCommand(1, 0),
                new DownCommand(),
                new GotoCommand(1, 1),
                new GotoCommand(0, 1),
                new GotoCommand(0, 2),
                new GotoCommand(1, 2),
                new GotoCommand(1, 3),
                new GotoCommand(2, 3),
                new GotoCommand(2, 2),
                new GotoCommand(4, 2),
                new GotoCommand(4, 1),
                new GotoCommand(2, 1),
                new GotoCommand(2, 0),
                new GotoCommand(1, 0),
                new UpCommand()
            })}
        };
    
    public static TheoryData<Sheet, Box, CutResult> VerticalBox =>
        new()
        {
            {
                Sheet.Create(3, 4).Value, Box.Create(1, 1, 1).Value,
                new CutResult(1,
                    new Command[]
                    {
                        new GotoCommand(1, 0),
                        new DownCommand(),
                        new GotoCommand(1, 1),
                        new GotoCommand(0, 1),
                        new GotoCommand(0, 2),
                        new GotoCommand(1, 2),
                        new GotoCommand(1, 4),
                        new GotoCommand(2, 4),
                        new GotoCommand(2, 2),
                        new GotoCommand(3, 2),
                        new GotoCommand(3, 1),
                        new GotoCommand(2, 1),
                        new GotoCommand(2, 0),
                        new GotoCommand(1, 0),
                        new UpCommand()
                    })
            }
        };
}