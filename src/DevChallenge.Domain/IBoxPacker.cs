using CSharpFunctionalExtensions;

namespace DevChallenge.Domain;

public interface IBoxPacker
{
    Result<IReadOnlyList<(int x, int y)>> Pack(Sheet sheet, Box template);
}
