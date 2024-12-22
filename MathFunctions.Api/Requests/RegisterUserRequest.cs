namespace MathFunctions.Api.Requests;

public class RegisterUserRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
