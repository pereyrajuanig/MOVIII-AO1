using MoviiiAo1.Api.Swagger;

namespace MoviiiAo1.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseMoviiiDevelopmentSwagger(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return app;

        app.UseMiddleware<SwaggerJsonBearerSecurityFixMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI(o => o.ConfigObject.PersistAuthorization = true);
        return app;
    }
}
