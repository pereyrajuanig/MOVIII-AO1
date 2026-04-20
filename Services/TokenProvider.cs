using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MoviiiAo1.Api.Models;

namespace MoviiiAo1.Api.Services;

public sealed class TokenProvider(IConfiguration configuration)
{
    public string GenerarToken(Usuario usuario)
    {
        var jwt = configuration.GetSection("Jwt");
        var secretKey = jwt["Secret"]!;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, usuario.Username),
                new Claim(ClaimTypes.Role, Roles.ADMIN),
            ]),
            Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue("Jwt:ExpirationInMinutes", 120)),
            SigningCredentials = credentials,
            Issuer = jwt["Issuer"],
            Audience = jwt["Audience"],
        };

        return new JsonWebTokenHandler().CreateToken(tokenDescriptor);
    }
}
