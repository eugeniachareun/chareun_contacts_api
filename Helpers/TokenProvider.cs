using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

public class TokenProvider(IConfiguration configuration)
{
    public string GenerarToken(Usuario usuario)
    {
        //Toma la clave secreta desde appsettings.json.
        string secretKey = configuration["Jwt:Secret"]!;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Sid, usuario.Id.ToString()),

        new Claim(ClaimTypes.NameIdentifier, usuario.Username),
        new Claim(ClaimTypes.Role, Roles.ADMIN)

    ]),
            Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("jwt:ExpirationInMinutes")),
            SigningCredentials = credentials,
            Issuer = configuration["jwt:Issuer"],
            Audience = configuration["jwt:Audience"]

        };

        var handler = new JsonWebTokenHandler();
        string token = handler.CreateToken(tokenDescriptor);

        return token;
    }

}