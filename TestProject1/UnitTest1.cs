using Core;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var service = new MathService();

        service.Calc();
    }
}