using ISOCI.DAL;
using ISOCI.DAL.Entities;
using MathEvaluation.Extensions;
using MathEvaluation.Parameters;

namespace Core;

public class MathService
{
    private readonly ApplicationContext _context;

    public MathService(ApplicationContext context)
    {
        _context = context;
    }

    public void AddExpression(string expression, List<string> paremNames)
    {
        List<ParamsEntity> parameters = new(paremNames.Count);

        foreach (var name in paremNames)
        {
            parameters.Add(new ParamsEntity
            {
                ParamName = name,
            });
        }

        ExpressionEntity expressionEntity = new()
        {
            ExpressionString = expression,
            Params = parameters
        };

        _context.Expressions.Add(expressionEntity);
        _context.SaveChanges();
    }


    public double ExecuteExpression(long expressionId, IEnumerable<ParametrValueDto> parameters)
    {
        var expression = _context.Expressions.Find(expressionId);

        List<ParamValueEntity> paramValueEntities = parameters
            .Select(x => new ParamValueEntity()
            {
                Param = _context.Params.Find(x.ParameterId),
                Value = x.Value
            })
            .ToList();

        MathParameters mathParameters = GetMathParametors(paramValueEntities);

        //var result = expression.ExpressionString.Evaluate(mathParameters);
        var result = expression.ExpressionString.Evaluate();

        _context.History.Add(new()
        {
            Expression = expression,
            ParamValues = paramValueEntities,
            Result = result
        });
        _context.SaveChanges();

        return result;
    }   


    private MathParameters GetMathParametors(List<ParamValueEntity> paramValueEntities)
    {
        var mathParameters = new MathParameters();
        foreach (var p in paramValueEntities)
        {
            mathParameters.BindVariable(p.Value, p.Param.ParamName);
        }

        return mathParameters;
    }
}

public class ParametrValueDto
{
    public required long ParameterId { get; set; }
    public required double Value { get; set; }
}