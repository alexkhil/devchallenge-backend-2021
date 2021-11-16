using DevChallenge.Domain;

namespace DevChallenge.Application.SimpleBox.Create;

public record CreateSimpleBoxResult(int Amount, IReadOnlyList<Command> Commands);