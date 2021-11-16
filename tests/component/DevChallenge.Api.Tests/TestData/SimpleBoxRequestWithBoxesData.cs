using DevChallenge.Api.Endpoints.SimpleBox;
using Xunit;

namespace DevChallenge.Api.Tests.TestData;

public class SimpleBoxRequestWithBoxesData : TheoryData<SimpleBoxRequest, SuccessResponse>
{
    public SimpleBoxRequestWithBoxesData()
    {
        Add(new SimpleBoxRequest(new SheetSize(4, 3), new BoxSize(1, 1, 1)), new SuccessResponse(1, new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { { "command", "START" } },
            new Dictionary<string, object> { { "command", "STOP" } },
        }));
    }
}