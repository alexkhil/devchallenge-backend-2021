namespace DevChallenge.Domain;

public abstract record Command();

public record StartCommand() : Command;

public record StopCommand() : Command;

public record DownCommand() : Command;

public record UpCommand() : Command;

public record GotoCommand(int X, int Y) : Command;