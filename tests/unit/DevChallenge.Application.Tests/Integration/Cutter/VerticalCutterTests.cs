using DevChallenge.Application.Integration.Cutter;
using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Application.Tests.TestData;
using DevChallenge.Domain;
using FluentAssertions;
using Xunit;

namespace DevChallenge.Application.Tests.Integration.Cutter;

public class VerticalCutterTests
{
    [Theory]
    [MemberData(nameof(InputData.VerticalBox), MemberType = typeof(InputData))]
    public void Cut_returns_commands_to_cut_passed_box_horizontally(Sheet sheet, Box box, CutResult expected)
    {
        var sut = new VerticalCutter();

        var actual = sut.Cut(sheet, box);

        actual.Should().BeEquivalentTo(expected);
    }
}