using DevChallenge.Domain;

namespace DevChallenge.Application.Integration.Cutter.Abstractions;

public interface ICutter
{
    CutResult Cut(Sheet sheet, Box template);
}