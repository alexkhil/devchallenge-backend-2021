using DevChallenge.Application.Integration.Cutter.Abstractions;

namespace DevChallenge.Application.SimpleBox.Create;

public record CreateSimpleBoxResult(int Amount, IReadOnlyList<Command> Commands);