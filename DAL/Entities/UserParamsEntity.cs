using CSharpFunctionalExtensions;

namespace ISOCI.DAL.Entities;

public class UserParamsEntity : Entity
{
    public required string ParamName { get; set; }
    public required double ParamValue { get; set; }
    public List<HistoryEntity> Histories { get; set; }
}

