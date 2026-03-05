using Articulos_Backend.Articulos;
using Articulos_Backend.Repositorios;
using ClientesASPNET;

namespace Articulos_Backend.Endpoints;
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
        })
        .Produces<Articulo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/articulos", (string? nombre) =>
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Results.Ok(repo.ObtenerArticulos());

            var articulo = repo.ObtenerPorNombre(nombre);
            return articulo is not null ? Results.Ok(articulo) : Results.NotFound();
        })
        .Produces<List<Articulo>>(StatusCodes.Status200OK)
        .Produces<Articulo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        app.MapPost("/articulos", (Articulo articulo) =>
        {
            var articuloExistente = repo.ObtenerPorNombre(articulo.nombre);
            if (articuloExistente is not null)
            {
                return Results.Conflict($"Ya existe un artículo con el nombre '{articulo.nombre}'.");
            }
            repo.Insertar(articulo);
            return Results.Created($"/Articulo/{articulo.id}", articulo);
        })
        .Produces<Articulo>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/articulos/{id:int}", (int id, Articulo updatedArticulo) =>
        {
            var articulo = repo.ObtenerPorId;
            if (articulo is null)
            {
                return Results.NotFound();
            }
            repo.Actualizar(updatedArticulo);
            return Results.Ok(articulo);
        })
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapDelete("/articulos/{id:int}", (int id) =>
        {
            var articulo = repo.ObtenerPorId(id);
            if (articulo is null)
            {
                return Results.NotFound();
            }
            repo.Eliminar(id);
            return Results.NoContent();
        })
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
