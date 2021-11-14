using System.Text.Json.Serialization;

namespace DevChallenge.Api.Endpoints.SimpleBox;

public record SimpleBoxRequest(SheetSize SheetSize, BoxSize BoxSize);

public record BoxSize(
    [property: JsonPropertyName("w")] int Width,
    [property: JsonPropertyName("d")] int Depth,
    [property: JsonPropertyName("h")] int Height);

public record SheetSize(
    [property: JsonPropertyName("w")] int Width,
    [property: JsonPropertyName("l")] int Length);