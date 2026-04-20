using MoviiiAo1.Api.Extensions;
using MoviiiAo1.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMoviiiSwagger();
builder.Services.AddMoviiiJwt(builder.Configuration);
builder.Services.AddMoviiiApplication();

var app = builder.Build();

app.UseMoviiiDevelopmentSwagger();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/minimal/contactos", (ContactoService svc) => Results.Ok(svc.ObtenerTodos()))
    .WithName("GetMinimalContactos");

app.MapControllers();
app.Run();
