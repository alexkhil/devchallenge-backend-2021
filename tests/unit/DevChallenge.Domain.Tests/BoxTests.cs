using DevChallenge.Domain.Tests.TestData;
using FluentAssertions;
using FluentAssertions.Execution;
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
}