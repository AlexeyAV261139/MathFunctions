using System.ComponentModel.DataAnnotations;

namespace MathFunctions.Api.Controllers;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
