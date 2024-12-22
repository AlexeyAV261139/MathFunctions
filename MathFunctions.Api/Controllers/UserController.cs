using Core.Services;
using MathFunctions.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MathFunctions.Api.Requests;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IResult Register(RegisterUserRequest request)
    {
        _userService.Register(request.UserName, request.Email, request.Password);
        return Results.Ok();
    }

    [HttpPost("login")]
    public IResult Login(LoginUserRequest request)
    {
        var token = _userService.Login(request.Login, request.Password);
        Response.Cookies.Append("Token", token);

        return Results.Ok(token);
    }
}