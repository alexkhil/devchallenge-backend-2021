using FluentAssertions;
using FluentAssertions.Execution;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace DevChallenge.Api.Tests;

public class SimpleBoxTests
{
    private readonly Uri endpointUri = new("/api/simple_box", UriKind.Relative);

    [Theory]
    [MemberData(nameof(SimpleBoxRequestWithNegativeValues))]
    public async Task Endpoint_called_with_negative_value_should_respond_with_status_code_422_and_error(SimpleBoxRequest request)
    {
        // Arrange
        await using var app = new DevChallengeApi();
        using var client = app.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync(endpointUri, request);
        var actual = await response.Content.ReadFromJsonAsync<FailResponse>();

        // Assert
        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        actual.Should().BeEquivalentTo(FailInputResponse);
    }

    [Theory]
    [MemberData(nameof(SimpleBoxRequestWithoutBoxes))]
    public async Task Endpoint_called_with_too_small_sheet_size_should_respond_with_status_code_422_and_error(SimpleBoxRequest request)
    {
        // Arrange
        await using var app = new DevChallengeApi();
        using var client = app.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync(endpointUri, request);
        var actual = await response.Content.ReadFromJsonAsync<FailResponse>();

        // Assert
        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        actual.Should().BeEquivalentTo(FailBoxPlacementResponse);
    }

    [Theory]
    [MemberData(nameof(SimpleBoxRequestWithBoxes))]
    public async Task Endpoint_called_with_valid_request_respond_with_status_code_200_and_boxes(SimpleBoxRequest request, int boxes)
    {
        // Arrange
        await using var app = new DevChallengeApi();
        using var client = app.CreateClient();

        // Act
        var response = await client.PostAsJsonAsync(endpointUri, request);
        var actual = await response.Content.ReadFromJsonAsync<SuccessResponse>();

        // Assert
        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        actual.Should().BeEquivalentTo(new SuccessResponse(boxes, new List<Command>()));
    }

    private static FailResponse FailInputResponse =>
        new("Invalid input format. Please use only positive integers");

    private static FailResponse FailBoxPlacementResponse =>
        new("Invalid sheet size. Too small for producing at least one box");

    public static TheoryData<SimpleBoxRequest> SimpleBoxRequestWithNegativeValues =>
        new ()
        {
            { new SimpleBoxRequest(new SheetSize(-1, 1), new BoxSize(1, 1, 1)) },
            { new SimpleBoxRequest(new SheetSize(1, -1), new BoxSize(1, 1, 1)) },
            { new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(-1, 1, 1)) },
            { new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(1, -1, 1)) },
            { new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(1, 1, -1)) }
        };

    public static TheoryData<SimpleBoxRequest> SimpleBoxRequestWithoutBoxes =>
        new()
        {
            { new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(1, 1, 1)) }
        };

    public static TheoryData<SimpleBoxRequest, int> SimpleBoxRequestWithBoxes =>
        new()
        {
            { new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(1, 1, 1)), 1 }
        };
}