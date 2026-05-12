using MTNegocios.MTEndpoints.Seguridad;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints.Seguridad;

public static class ConfiguracionEndpoints
{
    public static WebApplication MapConfiguracionEndpoints(this WebApplication app)
    {
        app.MapGet("/configuracion/{correo}", async (string correo, ConfiguracionMethods methods) =>
        {
            var configuracion = await methods.ObtenerConfiguracionPorCorreo(correo);
            return configuracion is not null
                ? Results.Ok(configuracion)
                : Results.NotFound(null);
        })//.RequireAuthorization(policy => policy.RequireRole(Roles.Admin****, Roles.User****))
            .Produces<Cliente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        app.MapPost("/guardar_configuracion/{correo}", async (string correo, ConfiguracionModel configuracion, ConfiguracionMethods methods) =>
        {
            var existente = await methods.ObtenerConfiguracionPorCorreo(correo);
            if (existente != null)
            {
                await methods.GuardarConfiguracionPorCorreo("", configuracion, correo);
                return Results.Ok(configuracion);
            }
            await methods.GuardarConfiguracionPorCorreo(Guid.NewGuid().ToString(), configuracion, correo);
            return Results.Created($"/configuracion/{correo}", configuracion);
        }).Produces<Cliente>(StatusCodes.Status201Created)
          .Produces(StatusCodes.Status409Conflict);
        return app;
    }
}
