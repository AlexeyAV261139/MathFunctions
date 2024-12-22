using CSharpFunctionalExtensions;

namespace DAL.Entities;

public class History : Entity
{
    public Formula Formula { get; set; }
    public long UserId { get;set; }
    public User User { get; set; }
    public List<ParametrValue> ParametorValues { get; set; }
    public double Result {  get; set; }

}
