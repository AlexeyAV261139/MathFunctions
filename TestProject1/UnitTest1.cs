using Core;
using ISOCI.DAL;
using ISOCI.DAL.Entities;

namespace TestProject1;

public class UnitTest1
{
    private readonly ApplicationContext _context = new ApplicationContext();

    [Fact]
    public void AddExpressionTestTest()
    {
        _context.Expressions.Add(new()
        {
            ExpressionString = "y = a*cos(x)*b*c",
            AdminParams = 
            [
                new AdminParamsEntity()
                {
                    ParamName = "a",
                    ParamValue = 1
                },
                new AdminParamsEntity()
                {
                    ParamName = "a",
                    ParamValue = 2
                }
            ]
        });
        _context.SaveChanges();
    }

    [Fact]
    public void CalculateFormulaTest()
    {
        _context.Expressions.Add(new()
        {
            ExpressionString = "y = a*cos(x)*b*c",
            AdminParams =
            [
                new AdminParamsEntity()
                {
                    ParamName = "a",
                    ParamValue = 1
                },
                new AdminParamsEntity()
                {
                    ParamName = "a",
                    ParamValue = 2
                }
            ]
        });
        _context.SaveChanges();
    }
}