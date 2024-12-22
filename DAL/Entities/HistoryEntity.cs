using CSharpFunctionalExtensions;

namespace ISOCI.DAL.Entities;

public class HistoryEntity : Entity
{
    public ExpressionEntity Expression { get; set; }

    public List<ParamValueEntity> ParamValues { get; set; } = [];

    public double Result { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;
}
