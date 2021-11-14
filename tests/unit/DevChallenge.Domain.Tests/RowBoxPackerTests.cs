using Xunit;
using FluentAssertions.Execution;
using FluentAssertions;

namespace DevChallenge.Domain.Tests;

public class RowBoxPackerTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void MyTestMethod(Sheet sheet, Box box, List<(int x, int y)> expected)
    {
        var sut = new RowBoxPacker();

        var result = sut.Pack(sheet, box);

        using var scope = new AssertionScope();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(expected);
    }

    public static TheoryData<Sheet, Box, List<(int x, int y)>> TestData => new()
    {
        { Sheet.Create(4, 3).Value, Box.Create(1, 1, 1).Value, new List<(int x, int y)>() { (0, 0) } },
        // { Sheet.Create(3, 4).Value, Box.Create(1, 1, 1).Value, 1 }
    };
}