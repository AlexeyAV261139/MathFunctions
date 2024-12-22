﻿using Core;
using ISOCI.DAL;
using ISOCI.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services;

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

    public double SquareOfTheDifference(double a, double b)
    {
        const long expressionId = 3;

        var expression = _context.Expressions
           .Include(x => x.AdminParams)
           .FirstOrDefault(x => x.Id == expressionId)!;

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "a", ParamValue = a},
            new UserParamsEntity(){ParamName = "b", ParamValue = b}
        ];

        double result = a * a - 2 * a * b - b * b;

        SaveHistory(expression, result, userParams);

        return result;
    }

    public double DifferenceOfSquares(double a, double b)
    {
        const long expressionId = 4;

        var expression = _context.Expressions
           .Include(x => x.AdminParams)
           .FirstOrDefault(x => x.Id == expressionId)!;

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "a", ParamValue = a},
            new UserParamsEntity(){ParamName = "b", ParamValue = b}
        ];

        double result = (a - b) * (a + b);

        SaveHistory(expression, result, userParams);

        return result;
    }

    public double CubeOfSum(double a, double b)
    {
        const long expressionId = 5;

        var expression = _context.Expressions
           .Include(x => x.AdminParams)
           .FirstOrDefault(x => x.Id == expressionId)!;

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "a", ParamValue = a},
            new UserParamsEntity(){ParamName = "b", ParamValue = b}
        ];

        double result = a * a * a + 3 * a * a * b + 3 * a * b * b + b * b * b;

        SaveHistory(expression, result, userParams);

        return result;
    }

    public double CubeOfDifference(double a, double b)
    {
        const long expressionId = 6;

        var expression = _context.Expressions
           .Include(x => x.AdminParams)
           .FirstOrDefault(x => x.Id == expressionId)!;

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "a", ParamValue = a},
            new UserParamsEntity(){ParamName = "b", ParamValue = b}
        ];

        double result = a * a * a - 3 * a * a * b + 3 * a * b * b - b * b * b;

        SaveHistory(expression, result, userParams);

        return result;
    }

    public double ACubeMinusBCube(double a, double b)
    {
        const long expressionId = 7;

        var expression = _context.Expressions
           .Include(x => x.AdminParams)
           .FirstOrDefault(x => x.Id == expressionId)!;

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "a", ParamValue = a},
            new UserParamsEntity(){ParamName = "b", ParamValue = b}
        ];

        double result = (a - b) * (a * a + a * b + b * b);

        SaveHistory(expression, result, userParams);

        return result;
    }

    public double ACubePlusBCube(double a, double b)
    {
        const long expressionId = 8;

        var expression = _context.Expressions
           .Include(x => x.AdminParams)
           .FirstOrDefault(x => x.Id == expressionId)!;

        List<UserParamsEntity> userParams =
        [
            new UserParamsEntity(){ParamName = "a", ParamValue = a},
            new UserParamsEntity(){ParamName = "b", ParamValue = b}
        ];

        double result = (a + b) * (a * a - a * b + b * b);

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