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
    public ActionResult<string> Login(LoginRequest request)
    {
        try
        {
            return _authService.login(request);
        }
        catch (System.Exception e)
        {
            
            return Forbid(e.Message);
        }

    }

    [HttpPost("register")]
    public ActionResult<string> Register(Usuario usuario)
    {
        try
        {
            return _authService.register(usuario);
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }

    }

    
}