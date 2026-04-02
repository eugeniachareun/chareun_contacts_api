using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<string> Login(string usuario, string contrasenia)
    {
        try
        {
            return _authService.login(usuario, contrasenia);
        }
        catch (System.Exception)
        {
            
            return Forbid();
        }

    }

    
}