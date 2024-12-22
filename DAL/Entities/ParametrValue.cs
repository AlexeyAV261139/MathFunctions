using CSharpFunctionalExtensions;

namespace DAL.Entities;

public class ParametrValue : Entity
{
    public Parametr Parametr { get; set; }
    public double Value { get; set; }
}
