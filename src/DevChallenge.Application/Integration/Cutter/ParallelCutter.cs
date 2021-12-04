using DevChallenge.Application.Integration.Cutter.Abstractions;
using DevChallenge.Domain;

namespace DevChallenge.Application.Integration.Cutter;

public class ParallelCutter : ICutter
{
    private readonly IEnumerable<ICutter> _cutters;

    public ParallelCutter(IEnumerable<ICutter> cutters)
    {
        _cutters = cutters;
    }

    public CutResult Cut(Sheet sheet, Box template)
    {
        var result = _cutters.AsParallel()
            .Select(cutter => cutter.Cut(sheet, template))
            .OrderByDescending(cutResult => cutResult.Amount)
            .First();

        return CreateCutResult(result);
    }

    private static CutResult CreateCutResult(CutResult cutResult)
    {
        var commands = new List<Command> { new StartCommand() };
        commands.AddRange(cutResult.Commands);
        commands.Add(new StopCommand());

        return new CutResult(cutResult.Amount, commands);
    }
}