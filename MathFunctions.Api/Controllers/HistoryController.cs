using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathFunctions.Api.Requests;

[ApiController]
[Route("[controller]")]
public class HistoryController(HistoryRepository historyRepository,
                              FormulaRepository formulaRepository,
                              UserRepository userRepository) : ControllerBase
{
    private readonly HistoryRepository _historyRepository = historyRepository;
    private readonly FormulaRepository _formulaRepository = formulaRepository;
    private readonly UserRepository _userRepository = userRepository;

    [Authorize]
    [HttpGet]
    public IResult GetHisory()
    {
        return Results.Ok();
    }

    [Authorize]
    [HttpGet]
    public IResult AddToHistory(AddToHistoryRequest request)
    {
        var formula = _formulaRepository.GetById(request.FormulaID);
        var user = _userRepository.GetById(request.UserId);
        var parametors = new List<ParametrValue>(request.Parametors.Count);
        for (var i = 0; i < formula.Parametrs.Count; i++)
        {
            parametors.Add(new ParametrValue()
            {
                Parametr = formula.Parametrs[i],
                Value = request.Parametors[i].Value
            });
        }

        var history = new History()
        {
            Formula = formula,
            Result = request.Result,
            User = user,
            ParametorValues = parametors,
        };

        _historyRepository.AddToHistory(history);

        return Results.Ok();
    }

    [Authorize]
    [HttpGet]
    public IResult GetUserHistory(long userId)
    {
        var allHistory = _historyRepository.GetAllHystoryByUserId(userId);
        return Results.Ok(allHistory);
    }
}