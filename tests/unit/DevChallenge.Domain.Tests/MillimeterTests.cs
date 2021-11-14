using DevChallenge.Domain.Tests.TestData;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace DevChallenge.Domain.Tests;

public class MillimeterTests
{
    [Theory]
    [ClassData(typeof(NegativeIntegerData))]
    public void Millimeter_with_negative_value_is_invalid(int value)
    {
        var result = Millimeter.Create(value);

        using var scope = new AssertionScope();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Messages.InvalidInput.NegativeIntegers);
    }

    [Theory]
    [InlineData(1)]
    public void Millimeter_with_positive_value_is_valid(int value)
    {
        var result = Millimeter.Create(value);

        using var scope = new AssertionScope();
        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().Be(value);
    }
}
