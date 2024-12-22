using CSharpFunctionalExtensions;

namespace ISOCI.DAL.Entities;

public class ExpressionEntity : Entity
{
    public required string ExpressionString { get; set; } = "";

    public required List<AdminParamsEntity> AdminParams { get; set; } = [];
}
