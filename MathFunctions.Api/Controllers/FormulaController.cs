using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MathFunctions.Api.Requests;

[ApiController]
[Route("[controller]")]
public class FormulaController : ControllerBase
{
    private readonly FormulaRepository _formulaRepository;

    public FormulaController(FormulaRepository formulaRepository)
    {
        _formulaRepository = formulaRepository;
    }   

    [Authorize(Policy = "AdminPolicy")]
    [HttpPost("CreateFormula")]
    public IResult CreateFormula(CreateFormulaRequest request)
    {
        var parametors = request.Parametors
            .Select(p => new Parametr { Name = p })
            .ToList();

        _formulaRepository.Create(new Formula(request.Formula, parametors));        

        return Results.Ok();
    }

    [Authorize(Policy = "AdminPolicy")]
    [HttpDelete("DeleteFormula")]
    public IResult DeleteFormula(long formulaId)
    {        
        _formulaRepository.Delete(formulaId);

        return Results.Ok();
    }

    [Authorize]
    [HttpGet]
    public IResult GetFormulas()
    {        
        var furmulas = _formulaRepository.GetAll();
        return Results.Ok(furmulas);
    }


}