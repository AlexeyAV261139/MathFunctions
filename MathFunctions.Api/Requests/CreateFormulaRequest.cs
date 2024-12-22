using System.ComponentModel.DataAnnotations;

public record CreateFormulaRequest(
    [Required] string Formula,
    [Required] string[] Parametors);

