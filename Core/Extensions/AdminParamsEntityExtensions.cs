using ISOCI.DAL.Entities;

namespace Core.Extensions;

public static class AdminParamsEntityExtensions
{
    public static double GetValueByName(this IEnumerable<AdminParamsEntity> parametors, string paramName)
    {
        double value = parametors
                .FirstOrDefault(x => x.ParamName == paramName)
                !.ParamValue;
        return value;
    }
}
