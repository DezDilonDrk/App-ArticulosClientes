using Articulos_Backend.Articulos;

namespace Articulos_Backend.Endpoints;
public static class ArticuloEndpoints
{
    public static WebApplication MapArticuloEndpoints(this WebApplication app)
    {
        var lista = new List<Articulo>
        {
            new Articulo(1, "Laptop", 999.99, "Electronics"),
            new Articulo(2, "Smartphone", 499.99, "Electronics"),
            new Articulo(3, "Table", 199.99, "Furniture")
        };

        app.MapGet("/articulos", () =>
        {
            return lista.ToArray();
        })
        .WithName("GetArticulo");

        app.MapGet("/articulos/{id:int}", (int id) =>
        {
            var articulo = lista.FirstOrDefault(a => a.id == id);
            return articulo is not null ? Results.Ok(articulo) : Results.NotFound();
        });

        app.MapGet("/articulos/{nombre}", (string nombre) =>
        {
            var articulo = lista.Where(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList;
            return articulo is not null ? Results.Ok(articulo) : Results.NotFound();
        });

        app.MapPost("/articulos", (Articulo articulo) =>
        {
            lista.Add(articulo);
            return Results.Created($"/Articulo/{articulo.id}", articulo);
        });

        app.MapPut("/articulos/{nombre}", (string nombre, Articulo updatedArticulo) =>
        {
            var articulo = lista.FirstOrDefault(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            if (articulo is null)
            {
                return Results.NotFound();
            }
            articulo.precio = updatedArticulo.precio;
            articulo.categoria = updatedArticulo.categoria;
            return Results.Ok(articulo);
        });

        app.MapDelete("/articulos/{nombre}", (string nombre) =>
        {
            var articulo = lista.FirstOrDefault(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            if (articulo is null)
            {
                return Results.NotFound();
            }
            lista.Remove(articulo);
            return Results.NoContent();
        });

        return app;
    }
}
