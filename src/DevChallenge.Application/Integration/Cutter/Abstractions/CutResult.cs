namespace DevChallenge.Application.Integration.Cutter.Abstractions;

public record CutResult(int Amount, IReadOnlyList<Command> Commands);