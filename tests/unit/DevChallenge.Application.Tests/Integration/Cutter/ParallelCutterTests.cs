using DevChallenge.Application.Integration.Cutter;
using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Application.Tests.TestData;
using DevChallenge.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace DevChallenge.Application.Tests.Integration.Cutter;

public class ParallelCutterTests
{
    [Theory]
    [ClassData(typeof(InputData))]
    public void Cut_returns_best_result_from_provided_cutters(Sheet sheet, Box box, CutResult cutResult)
    {
        var bestCutterMock = CreateCutterMock(sheet, box, cutResult.Amount, cutResult.Commands.ToArray());
        var worseCutterMock = CreateCutterMock(sheet, box, 0);
        
        var sut = new ParallelCutter(new[] { bestCutterMock.Object, worseCutterMock.Object });

        var actual = sut.Cut(sheet, box);

        var expected = CreateExpectedCutResult(cutResult.Amount, cutResult.Commands.ToArray());
        actual.Should().BeEquivalentTo(expected);
    }

    private static CutResult CreateExpectedCutResult(int amount, params Command[] commands)
    {
        var resultCommands = new List<Command> { new StartCommand() };
        resultCommands.AddRange(commands);
        resultCommands.Add(new StopCommand());

        return new CutResult(amount, resultCommands);
    }

    private static Mock<ICutter> CreateCutterMock(
        Sheet sheet,
        Box box,
        int amount,
        params Command[] commands)
    {
        var cutterMock = new Mock<ICutter>();
        cutterMock.Setup(x => x.Cut(sheet, box)).Returns(new CutResult(amount, commands));
        return cutterMock;
    }
}