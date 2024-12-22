using ISOCI.DAL;
using ISOCI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core;

public class MathService
{
    private readonly ApplicationContext _context;

    public MathService(ApplicationContext context)
    {
        _context = context;
    }

    public double CalcuclateFormula1(double x, double c)
    {
        const long expressionId = 1;

        var expression = _context.Expressions
            .Include(x => x.AdminParams)
            .FirstOrDefault(x => x.Id == expressionId);

        double a = expression!.AdminParams.GetValueByName("a");
        double b = expression!.AdminParams.GetValueByName("b");

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "x",ParamValue = x},
            new UserParamsEntity(){ParamName = "c",ParamValue = c}
        ];

        double result = a * Math.Cos(x) * b * c;

        SaveHistory(expression, result, userParams);       

        return result;
    }

    public double SquareOfTheSum(double a, double b)
    {
        const long expressionId = 2;

        var expression = _context.Expressions
           .Include(x => x.AdminParams)
           .FirstOrDefault(x => x.Id == expressionId)!;

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "a", ParamValue = a},
            new UserParamsEntity(){ParamName = "b", ParamValue = b}
        ];

        double result = a * a + 2 * a * b + b * b;

        SaveHistory(expression, result, userParams);

        return result;
    }

    private void SaveHistory(ExpressionEntity expression, double result, List<UserParamsEntity> userParams)
    {
        _context.History.Add(new()
        {
            Expression = expression,
            ApminParams = expression.AdminParams,
            UserParams = userParams,
            Result = result,
            DateTime = DateTime.Now
        });
        _context.SaveChanges();
    }
}



public class AdminService
{
    private readonly ApplicationContext _context;

    public AdminService(ApplicationContext context)
    {
        _context = context;
    }

    public void СhangeAdminParametors(long expressionId, List<AdminParamsEntity> adminParams)
    {
        var expression = _context.Expressions
            .Include(x => x.AdminParams)
            .FirstOrDefault(x => x.Id == expressionId)!;

        expression.AdminParams = adminParams;
    }
}
