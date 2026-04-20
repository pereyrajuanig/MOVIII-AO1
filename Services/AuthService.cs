using MoviiiAo1.Api.Models;

namespace MoviiiAo1.Api.Services;

public sealed class AuthService(TokenProvider tokenProvider)
{
    public string? TryLogin(string usuario, string password)
    {
        if (usuario != "admin" || password != "1234")
            return null;

        return tokenProvider.GenerarToken(new Usuario(usuario));
    }
}
