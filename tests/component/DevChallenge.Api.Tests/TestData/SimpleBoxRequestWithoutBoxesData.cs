using DevChallenge.Api.Endpoints.SimpleBox;
using Xunit;

namespace DevChallenge.Api.Tests.TestData;

public class SimpleBoxRequestWithoutBoxesData : TheoryData<SimpleBoxRequest>
{
    public SimpleBoxRequestWithoutBoxesData()
    {
        Add(new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(1, 1, 1)));
        Add(new SimpleBoxRequest(new SheetSize(2, 6), new BoxSize(1, 1, 1)));
        Add(new SimpleBoxRequest(new SheetSize(3, 3), new BoxSize(1, 1, 1)));
    }
}