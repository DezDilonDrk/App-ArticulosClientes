using Articulos_Backend.Articulos;

namespace Articulos_Backend.Endpoints;
public static class ArticuloEndpoints
{
    static List<Articulo> articulos = new List<Articulo>
        {
            new Articulo(1, "Laptop", 999.99, "Electronics"),
            new Articulo(2, "Smartphone", 499.99, "Electronics"),
            new Articulo(3, "Table", 199.99, "Furniture")
        };
    public static WebApplication MapArticuloEndpoints(this WebApplication app)
    {

        app.MapGet("/articulos/{id:int}", (int id) =>
        {
            var articulo = articulos.FirstOrDefault(a => a.id == id);
            return articulo is not null ? Results.Ok(articulo) : Results.NotFound();
        });
        app.MapGet("/articulos/{nombre}", (string nombre) =>
        {
            return Results.Ok(getArticulos(nombre));
        });
        app.MapPost("/articulos", (Articulo articulo) =>
        {
            articulos.Add(articulo);
            return Results.Created($"/Articulo/{articulo.id}", articulo);
        });
        app.MapPut("/articulos/{id:int}", (int id, Articulo updatedArticulo) =>
        {
            var articulo = articulos.FirstOrDefault(a => a.id == id);
            if (articulo is null)
            {
                return Results.NotFound();
            }
            articulo.nombre = updatedArticulo.nombre;
            articulo.precio = updatedArticulo.precio;
            articulo.categoria = updatedArticulo.categoria;
            return Results.Ok(articulo);
        });
        app.MapDelete("/articulos/{nombre}", (string nombre) =>
        {
            var articulo = articulos.FirstOrDefault(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            if (articulo is null)
            {
                return Results.NotFound();
            }
            articulos.Remove(articulo);
            return Results.NoContent();
        });

        return app;
    }

    private static List<Articulo> getArticulos(string nombre)
    {
        if (string.IsNullOrEmpty(nombre))
        {
            return articulos;
        }

        return articulos.Where(a => a.nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();

    }
}
