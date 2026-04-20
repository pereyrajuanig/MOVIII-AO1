using System.Text.Json.Serialization;

namespace MoviiiAo1.Api.Models;

public sealed class LoginRequest
{
    [JsonPropertyName("usuario")]
    public string Usuario { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
