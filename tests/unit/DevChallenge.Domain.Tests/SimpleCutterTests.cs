using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace DevChallenge.Domain.Tests;

public class SimpleCutterTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void Pack_single_box_in_matched_sheet(Sheet sheet, Box box, int expected)
    {
        var sut = new SimpleCutter();

        var result = sut.Cut(sheet, box);

        using var scope = new AssertionScope();
        result.Amount.Should().Be(expected);
    }

    public static TheoryData<Sheet, Box, int> TestData => new()
    {
        { Sheet.Create(4, 3).Value, Box.Create(1, 1, 1).Value, 1 },
        { Sheet.Create(3, 4).Value, Box.Create(1, 1, 1).Value, 1 },
        { Sheet.Create(8, 3).Value, Box.Create(1, 1, 1).Value, 2 },
        { Sheet.Create(8, 6).Value, Box.Create(1, 1, 1).Value, 4 },
        { Sheet.Create(6, 8).Value, Box.Create(1, 1, 1).Value, 4 },
    };
}