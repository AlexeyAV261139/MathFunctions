using CSharpFunctionalExtensions;

namespace ISOCI.DAL.Entities;

public class ExpressionEntity : Entity
{
    public string ExpressionString { get; set; } = "";

    public List<ParamsEntity> Params { get; set; } = [];
}
