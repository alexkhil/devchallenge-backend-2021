using DevChallenge.Api.Endpoints.SimpleBox;
using Xunit;

namespace DevChallenge.Api.Tests.TestData;

public class SimpleBoxRequestWithBoxesData : TheoryData<SimpleBoxRequest, SuccessResponse>
{
    public SimpleBoxRequestWithBoxesData()
    {
        Add(new SimpleBoxRequest(new SheetSize(4, 3), new BoxSize(1, 1, 1)), new SuccessResponse(1,
            new List<Dictionary<string, object>>
            {
                new() { { "command", "START" } },
                new() { { "command", "GOTO" }, { "x", 1 }, { "y", 0 } },
                new() { { "command", "DOWN" } },
                new() { { "command", "GOTO" }, { "x", 1 }, { "y", 1 } },
                new() { { "command", "GOTO" }, { "x", 0 }, { "y", 1 } },
                new() { { "command", "GOTO" }, { "x", 0 }, { "y", 2 } },
                new() { { "command", "GOTO" }, { "x", 1 }, { "y", 2 } },
                new() { { "command", "GOTO" }, { "x", 1 }, { "y", 3 } },
                new() { { "command", "GOTO" }, { "x", 2 }, { "y", 3 } },
                new() { { "command", "GOTO" }, { "x", 2 }, { "y", 2 } },
                new() { { "command", "GOTO" }, { "x", 4 }, { "y", 2 } },
                new() { { "command", "GOTO" }, { "x", 4 }, { "y", 1 } },
                new() { { "command", "GOTO" }, { "x", 2 }, { "y", 1 } },
                new() { { "command", "GOTO" }, { "x", 2 }, { "y", 0 } },
                new() { { "command", "GOTO" }, { "x", 1 }, { "y", 0 } },
                new() { { "command", "UP" } },
                new() { { "command", "STOP" } },
            }));
    }
}