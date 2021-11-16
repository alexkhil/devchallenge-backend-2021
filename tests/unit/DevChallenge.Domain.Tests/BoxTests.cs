using DevChallenge.Domain.Tests.TestData;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;

namespace DevChallenge.Domain.Tests;

public class BoxTests
{
    [Theory]
    [ClassData(typeof(NegativeIntegerData))]
    public void Box_with_negative_width_is_invalid(int width)
    {
        var result = Box.Create(width, 1, 1);

        using var scope = new AssertionScope();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Messages.InvalidInput.NegativeIntegers);
    }

    [Theory]
    [ClassData(typeof(NegativeIntegerData))]
    public void Box_with_negative_height_is_invalid(int height)
    {
        var result = Box.Create(1, height, 1);

        using var scope = new AssertionScope();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Messages.InvalidInput.NegativeIntegers);
    }

    [Theory]
    [ClassData(typeof(NegativeIntegerData))]
    public void Box_with_negative_depth_is_invalid(int depth)
    {
        var result = Box.Create(1, 1, depth);

        using var scope = new AssertionScope();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Messages.InvalidInput.NegativeIntegers);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    public void Box_with_positive_sides_is_valid(int width, int height, int depth)
    {
        var result = Box.Create(width, height, depth);

        using var scope = new AssertionScope();
        result.IsSuccess.Should().BeTrue();
        result.Value.Width.Value.Should().Be(width);
        result.Value.Height.Value.Should().Be(height);
        result.Value.Depth.Value.Should().Be(depth);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    public void CutHorizontaly_returns_commands_to_cut(int width, int height, int depth)
    {
        var box = Box.Create(width, height, depth).Value;

        var actual = box.CutHorizontaly(0, 0);

        var expected = new List<Command>
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
        };
        ShouldBeEquivalent(expected, actual);
    }

    [Theory]
    [InlineData(1, 1, 1)]
    public void CutVerticaly_returns_commands_to_cut(int width, int height, int depth)
    {
        var box = Box.Create(width, height, depth).Value;

        var actual = box.CutVerticaly(0, 0);

        var expected = new List<Command>
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
            };
        ShouldBeEquivalent(expected, actual);
    }

    private static void ShouldBeEquivalent(IEnumerable<Command> expected, IEnumerable<Command> actual)
    {
        var stringActual = actual.Select(x => x.ToString()).ToList();
        var stringExpected = expected.Select(x => x.ToString()).ToList();
        stringActual.Should().BeEquivalentTo(stringExpected);
    }
}