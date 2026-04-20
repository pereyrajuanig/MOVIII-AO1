using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviiiAo1.Api.Models;
using MoviiiAo1.Api.Services;

namespace MoviiiAo1.Api.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController(AuthService authService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginRequest request)
    {
        var token = authService.TryLogin(request.Usuario, request.Password);
        return token is null ? Unauthorized() : Ok(token);
    }
}
