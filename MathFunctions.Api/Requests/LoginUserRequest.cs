using System.ComponentModel.DataAnnotations;

namespace MathFunctions.Api.Requests;

public record LoginUserRequest(
    [Required] string Login,
    [Required] string Password);
