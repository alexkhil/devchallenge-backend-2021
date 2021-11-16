namespace DevChallenge.Domain;

public interface ICutter
{
    (int Amount, IReadOnlyList<Command> Commands) Cut(Sheet sheet, Box template);
}
