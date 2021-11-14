using DevChallenge.Domain.Tests.TestData;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace DevChallenge.Domain.Tests;

public class SheetTests
{
    [Theory]
    [ClassData(typeof(NegativeIntegerData))]
    public void Sheet_with_negative_width_is_invalid(int width)
    {
        var result = Sheet.Create(width, 1);

        using var scope = new AssertionScope();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Messages.InvalidInput.NegativeIntegers);
    }

    [Theory]
    [ClassData(typeof(NegativeIntegerData))]
    public void Sheet_with_negative_height_is_invalid(int height)
    {
        var result = Sheet.Create(1, height);

        using var scope = new AssertionScope();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Messages.InvalidInput.NegativeIntegers);
    }

    [Theory]
    [InlineData(1, 1)]
    public void Sheet_with_positive_sides_is_valid(int width, int height)
    {
        var result = Sheet.Create(width, height);

        using var scope = new AssertionScope();
        result.IsSuccess.Should().BeTrue();
        result.Value.Width.Value.Should().Be(width);
        result.Value.Height.Value.Should().Be(height);
    }

    [Theory]
    [InlineData(1, 1)]
    public void Sheet_with_positive_sides_is_valid1(int width, int height)
    {
        var result = Sheet.Create(width, height);

        using var scope = new AssertionScope();
        result.IsSuccess.Should().BeTrue();
        result.Value.Width.Value.Should().Be(width);
        result.Value.Height.Value.Should().Be(height);
    }
}