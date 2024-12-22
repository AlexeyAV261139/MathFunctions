using System.ComponentModel.DataAnnotations;

namespace MathFunctions.Api.Requests;

public record AddToHistoryRequest(
    [Required] long FormulaID,
    [Required] long UserId,
    [Required] List<ParametorValueRequestField> Parametors,
    [Required] double Result);


public record ParametorValueRequestField(
    [Required] string Parametor,
    [Required] double Value);
