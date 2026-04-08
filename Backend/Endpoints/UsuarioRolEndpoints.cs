using Articulos_Backend.Repositorios;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints;

public static class UsuarioRolEndpoints
{
    public static WebApplication MapUsuarioRolEndpoints(this WebApplication app, UsuarioRolRepository repo)
    {
        app.MapGet("/usuario-roles", () =>
        {
            var list = repo.ObtenerAll();
            return list is not null ? Results.Ok(list) : Results.NotFound();
        })
        .Produces<IEnumerable<UsuarioRol>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuario-roles/usuario/{email}", (string email) =>
        {
            var roles = repo.ObtenerRolesPorUsuario(email);
            return Results.Ok(roles);
        })
        .Produces<IEnumerable<Rol>>(StatusCodes.Status200OK);

        app.MapGet("/usuario-roles/rol/{id:int}", (int id) =>
        {
            var usuarios = repo.ObtenerPorRol(id);
            return Results.Ok(usuarios);
        })
        .Produces<IEnumerable<UsuarioRol>>(StatusCodes.Status200OK);

        app.MapDelete("/usuario-roles/{rolId:int}/{email}", (int rolId, string email) =>
        {
            var existente = repo.ObtenerPorRolYUsuario(rolId, email);
            if (existente is null) return Results.NotFound();
            repo.Eliminar(rolId, email);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
