using DevChallenge.Application.Integration.Cutter;
using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Application.Tests.TestData;
using DevChallenge.Domain;
using FluentAssertions;
using Xunit;

namespace DevChallenge.Application.Tests.Integration.Cutter;

public class HorizontalCutterTests
{
    [Theory]
    [MemberData(nameof(InputData.HorizontalBox), MemberType = typeof(InputData))]
    public void Cut_returns_commands_to_cut_passed_box_horizontally(Sheet sheet, Box box, CutResult expected)
    {
        var sut = new HorizontalCutter();

        var actual = sut.Cut(sheet, box);

        actual.Should().BeEquivalentTo(expected);
    }
}