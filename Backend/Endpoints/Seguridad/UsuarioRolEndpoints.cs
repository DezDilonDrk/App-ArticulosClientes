using MTNegocios.MTEndpoints.Seguridad;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints.Seguridad;

public static class UsuarioRolEndpoints
{
    public static WebApplication MapUsuarioRolEndpoints(this WebApplication app)
    {
        app.MapGet("/usuario-roles", async (UsuarioRolMethods methods) =>
        {
            var list = await methods.ObtenerAll();
            return list is not null ? Results.Ok(list) : Results.NotFound();
        })
        .Produces<IEnumerable<UsuarioRol>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuario-roles/usuario/{email}", async (string email, UsuarioRolMethods methods) =>
        {
            var roles = await methods.ObtenerRolesPorUsuario(email);
            return Results.Ok(roles);
        })
        .Produces<IEnumerable<Rol>>(StatusCodes.Status200OK);

        app.MapGet("/usuario-roles/rol/{id:int}", async (int id, UsuarioRolMethods methods) =>
        {
            var usuarios = await methods.ObtenerPorRol(id);
            return Results.Ok(usuarios);
        })
        .Produces<IEnumerable<UsuarioRol>>(StatusCodes.Status200OK);

        app.MapDelete("/usuario-roles/{rolId:int}/{email}", async (int rolId, string email, UsuarioRolMethods methods) =>
        {
            var existente = await methods.ObtenerPorRolYUsuario(rolId, email);
            if (existente is null) return Results.NotFound();
            await methods.Eliminar(rolId, email);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
