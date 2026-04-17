using Articulos_Backend.Repositorios.Seguridad;
using MTCore_AC.Entidades;
using Articulos_Backend.JWT;

namespace Articulos_Backend.Endpoints.Seguridad;

public static class RolEndpoints
{
    public static WebApplication MapRolEndpoints(this WebApplication app, RolRepository repo)
    {
        app.MapGet("/roles", () =>
        {
            var roles = repo.ObtenerRoles();
            return roles is not null ? Results.Ok(roles) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<IEnumerable<Rol>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/roles/nombres", () =>
        {
            var nombres = repo.ObtenerNombreRoles();
            return nombres is not null ? Results.Ok(nombres) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<IEnumerable<Rol>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/roles/{id:int}", (int id) =>
        {
            var rol = repo.ObtenerPorId(id);
            return rol is not null ? Results.Ok(rol) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/roles/nombre/{nombre}", (string nombre) =>
        {
            var rol = repo.ObtenerPorNombre(nombre);
            return rol is not null ? Results.Ok(rol) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/roles", (Rol rol) =>
        {
            var existente = repo.ObtenerPorNombre(rol.Nombre);
            if (existente != null) { throw new InvalidOperationException($"Ya existe un rol con nombre '{rol.Nombre}'"); }
            int id = repo.Insertar(rol);
            rol.Id = id;
            return Results.Created($"/roles/{rol.Id}", rol);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);

        app.MapPut("/roles/{id:int}", (int id, Rol updatedRol) =>
        {
            var existing = repo.ObtenerPorId(id) ?? throw new KeyNotFoundException("Rol no encontrado");
            updatedRol.Id = id;
            repo.Actualizar(updatedRol);
            var refreshed = repo.ObtenerPorId(id) ?? updatedRol;
            return Results.Ok(refreshed);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        app.MapDelete("/roles/{id:int}", (int id) =>
        {
            var rol = repo.ObtenerPorId(id) ?? throw new KeyNotFoundException("Rol no encontrado");
            repo.Eliminar(id);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
