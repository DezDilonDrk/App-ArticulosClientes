using Microsoft.Identity.Client;
using MTCore_AC.Entidades;
using Articulos_Backend.JWT;
using Articulos_Backend.Repositorios.Almacen;

namespace Articulos_Backend.Endpoints.Almacen;
public static class ArticuloEndpoints
{
    /* static List<Articulo> articulos = new List<Articulo>
        {
            new Articulo(1, "Laptop", 999.99, "Electronics"),
            new Articulo(2, "Smartphone", 499.99, "Electronics"),
            new Articulo(3, "Table", 199.99, "Furniture")
        }; */
    public static WebApplication MapArticuloEndpoints(this WebApplication app, ArticuloRepository repo)
    {

        app.MapGet("/articulos/{id:int}", (int id) =>
        {
            var articulo = repo.ObtenerPorId(id);
            return articulo is not null ? Results.Ok(articulo) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminArticulos, Roles.UserArticulos))
        .Produces<Articulo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/articulos", (string? nombre) =>
        {
            if (string.IsNullOrWhiteSpace(nombre)) { return Results.Ok(repo.ObtenerArticulos()); }
            var articulo = repo.ObtenerPorNombre(nombre) ?? throw new KeyNotFoundException("Artículo no encontrado");
            return Results.Ok(articulo);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminArticulos, Roles.UserArticulos))
        .Produces<List<Articulo>>(StatusCodes.Status200OK)
        .Produces<Articulo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        app.MapPost("/articulos", (Articulo articulo) =>
        {
            var existente = repo.ObtenerPorNombreExacto(articulo.nombre);
            if (existente != null) { throw new InvalidOperationException($"Ya existe un artículo con nombre '{articulo.nombre}'"); }              
            int id = repo.Insertar(articulo);
            articulo.id = id;
            return Results.Created($"/articulos/{articulo.id}", articulo);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminArticulos))
        .Produces<Articulo>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/articulos/{id:int}", (int id, Articulo updatedArticulo) =>
        {
            var existing = repo.ObtenerPorId(id) ?? throw new KeyNotFoundException("Artículo no encontrado");
            updatedArticulo.id = id;
            repo.Actualizar(updatedArticulo);
            var refreshed = repo.ObtenerPorId(id) ?? updatedArticulo;
            return Results.Ok(refreshed);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminArticulos))
.Produces<Articulo>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.Produces(StatusCodes.Status409Conflict);
        app.MapDelete("/articulos/{id:int}", (int id) =>
        {
            var articulo = repo.ObtenerPorId(id) ?? throw new KeyNotFoundException("Artículo no encontrado");
            repo.Eliminar(id);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminArticulos))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }

    /* private static List<Articulo> getArticulos(string nombre)
    {
        if (string.IsNullOrEmpty(nombre))
        {
            return articulos;
        }

        return articulos.Where(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

    } */
}
