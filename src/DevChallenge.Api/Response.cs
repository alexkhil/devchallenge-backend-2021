using System.Text.Json.Serialization;

namespace DevChallenge.Api;

abstract record Response(bool Success);

record FailResponse(string Error) : Response(false);

record SuccessResponse(int Amount, IReadOnlyList<Command> Programm) : Response(true);

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