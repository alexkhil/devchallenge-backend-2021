using DevChallenge.Api.Endpoints.SimpleBox;
using Xunit;

namespace DevChallenge.Api.Tests.TestData;

public class SimpleBoxRequestWithBoxesData : TheoryData<SimpleBoxRequest, SuccessResponse>
{
    public SimpleBoxRequestWithBoxesData()
    {
        Add(new SimpleBoxRequest(new SheetSize(4, 3), new BoxSize(1, 1, 1)), new SuccessResponse(1, new List<Dictionary<string, object>>
        {

        }));
        //Add(new SimpleBoxRequest(new SheetSize(3, 4), new BoxSize(1, 1, 1)), 1);
        //Add(new SimpleBoxRequest(new SheetSize(8, 3), new BoxSize(1, 1, 1)), 2);
        //Add(new SimpleBoxRequest(new SheetSize(3, 8), new BoxSize(1, 1, 1)), 2);
        //Add(new SimpleBoxRequest(new SheetSize(4, 6), new BoxSize(1, 1, 1)), 2);
        //Add(new SimpleBoxRequest(new SheetSize(6, 4), new BoxSize(1, 1, 1)), 2);
    }
}