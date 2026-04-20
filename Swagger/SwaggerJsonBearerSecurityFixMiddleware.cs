using System.Text;

namespace MoviiiAo1.Api.Swagger;

/// <summary>
/// Microsoft.OpenApi 2.x serializa security como "#/components/securitySchemes/Bearer", que Swagger UI no interpreta;
/// el token no se envía. Reemplazar por la clave correcta "Bearer" (OpenAPI 3).
/// </summary>
public sealed class SwaggerJsonBearerSecurityFixMiddleware(RequestDelegate next)
{
    private static readonly string WrongKey = "\"#/components/securitySchemes/Bearer\"";
    private static readonly string RightKey = "\"Bearer\"";

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Path.StartsWithSegments("/swagger/v1/swagger.json"))
        {
            await next(context);
            return;
        }

        var originalBody = context.Response.Body;
        await using var buffer = new MemoryStream();
        context.Response.Body = buffer;

        await next(context);

        buffer.Position = 0;
        var json = await new StreamReader(buffer, Encoding.UTF8).ReadToEndAsync();
        json = json.Replace(WrongKey, RightKey, StringComparison.Ordinal);

        context.Response.Body = originalBody;
        context.Response.Headers.Remove("Content-Length");
        var bytes = Encoding.UTF8.GetBytes(json);
        context.Response.ContentLength = bytes.Length;
        await context.Response.Body.WriteAsync(bytes);
    }
}
