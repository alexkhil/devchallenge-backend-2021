using DevChallenge.Application.Integration.Cutter;
using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Domain;
using FluentAssertions;
using Xunit;

namespace DevChallenge.Application.Tests.Integration.Cutter;

public class HorizontalCutterTests
{
    [Theory]
    [MemberData(nameof(Data))]
    public void Cut_returns_commands_to_cut_passed_box_horizontally(Sheet sheet, Box box, CutResult expected)
    {
        var sut = new HorizontalCutter();

        var actual = sut.Cut(sheet, box);

        actual.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<Sheet, Box, CutResult> Data =>
        new ()
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
}