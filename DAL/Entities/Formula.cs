using CSharpFunctionalExtensions;

namespace DAL.Entities;

public class Formula : Entity
{    
    public string FormulaString { get; set; }

    public List<Parametr> Parametrs { get; set; }

    public Formula() { }

    public Formula(string formulaString, List<Parametr> parametrs)
    {
        FormulaString = formulaString;
        Parametrs = parametrs;
    }
}
