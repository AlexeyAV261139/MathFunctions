using CSharpFunctionalExtensions;

namespace ISOCI.DAL.Entities;

public class ParameterEntity : Entity
{
    public string Name { get; set; }
    public double Value { get; set; }
}