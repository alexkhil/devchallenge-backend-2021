using DevChallenge.Api.Endpoints.SimpleBox;
using DevChallenge.Api.Tests.TestData;
using DevChallenge.Domain;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace DevChallenge.Api.Tests;

public class SimpleBoxTests
{
    [Theory]
    [ClassData(typeof(SimpleBoxRequestWithNegativeValuesData))]
    public async Task Endpoint_called_with_negative_value_should_respond_with_status_code_422_and_error(SimpleBoxRequest request)
    {
        var response = await PostAsync(request);
        var actual = await response.Content.ReadFromJsonAsync<FailResponse>();

        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        actual.Should().BeEquivalentTo(new FailResponse(Messages.InvalidInput.NegativeIntegers));
    }

    [Theory]
    [ClassData(typeof(SimpleBoxRequestWithoutBoxesData))]
    public async Task Endpoint_called_with_too_small_sheet_size_should_respond_with_status_code_422_and_error(SimpleBoxRequest request)
    {
        var response = await PostAsync(request);
        var actual = await response.Content.ReadFromJsonAsync<FailResponse>();

        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        actual.Should().BeEquivalentTo(new FailResponse(Messages.InvalidSheet.TooSmall));
    }

    [Theory]
    [ClassData(typeof(SimpleBoxRequestWithBoxesData))]
    public async Task Endpoint_called_with_valid_request_respond_with_status_code_200_and_boxes(SimpleBoxRequest request, SuccessResponse expected)
    {
        var response = await PostAsync(request);
        var actual = await response.Content.ReadFromJsonAsync<SuccessResponse>();

        using var scope = new AssertionScope();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        actual.Should().BeEquivalentTo(expected);
    }

    private static async Task<HttpResponseMessage> PostAsync(SimpleBoxRequest request)
    {
        await using var app = new DevChallengeApi();
        using var client = app.CreateClient();
        return await client.PostAsJsonAsync(new Uri("/api/simple_box", UriKind.Relative), request);
    }
}