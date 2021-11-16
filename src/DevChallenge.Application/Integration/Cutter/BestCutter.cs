using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Domain;

namespace DevChallenge.Application.Integration.Cutter;

public class BestCutter : ICutter
{
    private readonly IEnumerable<ICutter> _cutters;

    public BestCutter(IEnumerable<ICutter> cutters)
    {
        _cutters = cutters;
    }

    public CutResult Cut(Sheet sheet, Box template)
    {
        var bestResult = new CutResult(0, new List<Command>());
        foreach (var cutter in _cutters)
        {
            var result = cutter.Cut(sheet, template);
            if (bestResult.Amount < result.Amount)
            {
                bestResult = result;
            }
        }

        var commands = new List<Command> { new StartCommand() };
        commands.AddRange(bestResult.Commands);
        commands.Add(new StopCommand());

        return new CutResult(bestResult.Amount, commands);
    }
}