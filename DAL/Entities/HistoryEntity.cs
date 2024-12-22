using CSharpFunctionalExtensions;

namespace ISOCI.DAL.Entities;

public class HistoryEntity : Entity
{
    public required ExpressionEntity Expression { get; set; }

    public List<AdminParamsEntity> ApminParams { get; set; } = [];

    public List<UserParamsEntity> UserParams { get; set; } = [];

    public double Result { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;
}
