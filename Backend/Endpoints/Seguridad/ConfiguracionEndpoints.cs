using Articulos_Backend.Repositorios.Seguridad;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints.Seguridad;

public static class ConfiguracionEndpoints
{
    public static WebApplication MapConfiguracionEndpoints(this WebApplication app, ConfiguracionRepository repo)
    {
        app.MapGet("/configuracion/{correo}", (string correo) =>
        {
            var configuracion = repo.ObtenerConfiguracionPorCorreo(correo);
            return configuracion is not null
                ? Results.Ok(configuracion)
                : Results.NotFound(null);
        })//.RequireAuthorization(policy => policy.RequireRole(Roles.Admin****, Roles.User****))
            .Produces<Cliente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        app.MapPost("/guardar_configuracion/{correo}", (string correo, ConfiguracionModel configuracion) =>
        {
            var existente = repo.ObtenerConfiguracionPorCorreo(correo);
            if (existente != null)
            {
                repo.GuardarConfiguracionPorCorreo("", configuracion, correo);
                return Results.Ok(configuracion);
            }
            repo.GuardarConfiguracionPorCorreo(Guid.NewGuid().ToString(), configuracion, correo);
            return Results.Created($"/configuracion/{correo}", configuracion);
        }).Produces<Cliente>(StatusCodes.Status201Created)
          .Produces(StatusCodes.Status409Conflict);
        return app;
    }
}
