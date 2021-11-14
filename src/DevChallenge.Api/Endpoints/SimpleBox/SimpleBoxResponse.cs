using System.Text.Json.Serialization;

namespace DevChallenge.Api.Endpoints.SimpleBox;

abstract record SimpleBoxResponse(bool Success);

record FailResponse(string Error) : SimpleBoxResponse(false);

record SuccessResponse(int Amount, IReadOnlyList<Command> Programm) : SimpleBoxResponse(true);

abstract record Command([property: JsonPropertyName("command")] CommandType Type);

record Start() : Command(CommandType.Start);

record Stop() : Command(CommandType.Stop);

record Down() : Command(CommandType.Down);

record Up() : Command(CommandType.Up);

record Goto(int X, int Y) : Command(CommandType.Goto);

enum CommandType
{
    None = 0,
    Start,
    Stop,
    Down,
    Up,
    Goto,
}