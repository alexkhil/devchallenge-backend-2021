using CSharpFunctionalExtensions;

namespace DevChallenge.Domain;

public class Millimeter : SimpleValueObject<int>
{
    private Millimeter(int value) : base(value)
    {
    }

    public static Result<Millimeter> Create(int millimetre) =>
        Result.SuccessIf(millimetre > 0, new Millimeter(millimetre), Messages.InvalidInput.NegativeIntegers);
}