using Core;
using ISOCI.DAL;

namespace TestProject1;

public class UnitTest1
{
    private readonly ApplicationContext _context = new ApplicationContext();

    [Fact]
    public void AddExpressionTestTest()
    {
        MathService _mathService = new(_context);

        _mathService.AddExpression("22888.32 * 30 / 323.34 / .5 - -1 / (2 + 22888.32) * 4 - 6", []);
    }

    [Fact]
    public void ExecuteExpressionWithoutParamsTest()
    {
        MathService _mathService = new(_context);

        var x1 = _mathService.Test();

        var result = _mathService.ExecuteExpression(1, []);
    }
}