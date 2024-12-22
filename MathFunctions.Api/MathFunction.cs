namespace Core;
public class MathFunction
{
    public double Pifagor(double a, double b) =>
        Math.Sqrt(a * a + b * b);        
}

public class MathService
{
    private readonly MathFunction _functions = new();
   
}
