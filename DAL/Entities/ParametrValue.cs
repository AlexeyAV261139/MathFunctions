using CSharpFunctionalExtensions;

namespace DAL.Entities;

public class ParametrValue : Entity
{
    public string Parametr { get; set; }
    public double Value { get; set; }
}
