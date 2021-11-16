namespace DevChallenge.Api.Endpoints.SimpleBox;

public abstract record SimpleBoxResponse(bool Success);

public record FailResponse(string Error) : SimpleBoxResponse(false);

public record SuccessResponse(int Amount, IReadOnlyList<Dictionary<string, object>> Program) : SimpleBoxResponse(true);