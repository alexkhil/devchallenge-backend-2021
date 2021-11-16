using DevChallenge.Api.Endpoints.SimpleBox;
using Xunit;

namespace DevChallenge.Api.Tests.TestData;

public class SimpleBoxRequestWithNegativeValuesData : TheoryData<SimpleBoxRequest>
{
    public SimpleBoxRequestWithNegativeValuesData()
    {
        Add(new SimpleBoxRequest(new SheetSize(-1, 1), new BoxSize(1, 1, 1)));
        Add(new SimpleBoxRequest(new SheetSize(1, -1), new BoxSize(1, 1, 1)));
        Add(new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(-1, 1, 1)));
        Add(new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(1, -1, 1)));
        Add(new SimpleBoxRequest(new SheetSize(1, 1), new BoxSize(1, 1, -1)));
    }
}