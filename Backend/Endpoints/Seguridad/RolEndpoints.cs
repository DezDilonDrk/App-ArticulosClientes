using MTNegocios.Repositorios.Seguridad;
using MTCore_AC.Entidades;
using MTNegocios.MTEndpoints.Seguridad;

namespace Articulos_Backend.Endpoints.Seguridad;

public static class RolEndpoints
{
    public static WebApplication MapRolEndpoints(this WebApplication app)
    {
        app.MapGet("/roles", async (RolMethods methods) =>
        {
            var roles = await methods.ObtenerRoles();
            return roles is not null ? Results.Ok(roles) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<IEnumerable<Rol>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/roles/nombres", async (RolMethods methods) =>
        {
            var nombres = await methods.ObtenerNombreRoles();
            return nombres is not null ? Results.Ok(nombres) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<IEnumerable<Rol>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/roles/{id:int}", async (int id, RolMethods methods) =>
        {
            var rol = await methods.ObtenerPorId(id);
            return rol is not null ? Results.Ok(rol) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/roles/nombre/{nombre}", async (string nombre, RolMethods methods) =>
        {
            var rol = await methods.ObtenerPorNombre(nombre);
            return rol is not null ? Results.Ok(rol) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/roles", async (Rol rol, RolMethods methods) =>
        {
            var existente = await methods.ObtenerPorNombre(rol.Nombre);
            if (existente != null) { throw new InvalidOperationException($"Ya existe un rol con nombre '{rol.Nombre}'"); }
            int id = await methods.Insertar(rol);
            rol.Id = id;
            return Results.Created($"/roles/{rol.Id}", rol);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);

        app.MapPut("/roles/{id:int}", async (int id, Rol updatedRol, RolMethods methods) =>
        {
            var existing = await methods.ObtenerPorId(id) ?? throw new KeyNotFoundException("Rol no encontrado");
            updatedRol.Id = id;
            await methods.Actualizar(id, updatedRol);
            var refreshed = await methods.ObtenerPorId(id) ?? updatedRol;
            return Results.Ok(refreshed);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Rol>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);

        app.MapDelete("/roles/{id:int}", async (int id, RolMethods methods) =>
        {
            var rol = await methods.ObtenerPorId(id) ?? throw new KeyNotFoundException("Rol no encontrado");
            await methods.Eliminar(id);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
