using CSharpFunctionalExtensions;

namespace ISOCI.DAL.Entities;

public class ParamValueEntity : Entity
{
    public ParamsEntity Param { get; set; }

    public double Value { get; set; }
}
