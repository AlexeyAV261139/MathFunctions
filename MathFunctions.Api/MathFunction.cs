using MathEvaluation.Extensions;
using MathEvaluation.Parameters;

namespace Core;
public class MathFunction
{
    public double Pifagor(double a, double b) =>
        Math.Sqrt(a * a + b * b);        
}

public class MathService
{
    private readonly MathFunction _functions = new();

    public void Calc()
    {
        var x1 = 0.5;
        var x2 = -0.5;
        var sqrt = Math.Sqrt;
        Func<double, double> ln = Math.Log;

        var value1 = "ln(1/-x1 + sqrt(1/(x2*x2) + 1))"
            .Evaluate(new { x1, x2, sqrt, ln });

        var parameters = new MathParameters();
        parameters.BindVariable(x1);
        parameters.BindVariable(x2);
        parameters.BindFunction(Math.Sqrt);
        parameters.BindFunction(d => Math.Log(d), "ln");

        var value2 = "ln(1/-x1 + Math.Sqrt(1/(x2*x2) + 1))"
            .Evaluate(parameters);
    }
}
