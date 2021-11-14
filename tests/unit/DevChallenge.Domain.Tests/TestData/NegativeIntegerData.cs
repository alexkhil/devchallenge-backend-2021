using Xunit;

namespace DevChallenge.Domain.Tests.TestData;

public class NegativeIntegerData : TheoryData<int>
{
    public NegativeIntegerData()
    {
        Add(0);
        Add(-1);
    }
}