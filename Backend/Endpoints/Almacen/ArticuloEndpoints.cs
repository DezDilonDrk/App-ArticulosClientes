using MTCore_AC.Entidades;
using Articulos_Backend.JWT;
using MTNegocios.MTEndpoints.Almacen;
using MTCore_AC.DTO;
using MTNegocios.MTEndpoints.BBDD;

namespace Articulos_Backend.Endpoints.Almacen;
public static class ArticuloEndpoints
{
    /* static List<Articulo> articulos = new List<Articulo>
        {
            new Articulo(1, "Laptop", 999.99, "Electronics"),
            new Articulo(2, "Smartphone", 499.99, "Electronics"),
            new Articulo(3, "Table", 199.99, "Furniture")
        }; */
    public static WebApplication MapArticuloEndpoints(this WebApplication app)
    {


        app.MapGet("/articulos/{id}", async (string id, ArticuloMethods methods) =>
        {
            var articulo = await methods.ObtenerPorId(id);
            return articulo is not null ? Results.Ok(articulo) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen, Roles.UserAlmacen))
        .Produces<Articulo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/articulos", async (string? nombre, ArticuloMethods methods) =>
        {
            if (string.IsNullOrWhiteSpace(nombre)) { return Results.Ok(await methods.ObtenerArticulos()); }
            var articulo = await methods.ObtenerPorNombre(nombre) ?? throw new KeyNotFoundException("Artículo no encontrado");
            return Results.Ok(articulo);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen, Roles.UserAlmacen))
        .Produces<List<Articulo>>(StatusCodes.Status200OK)
        .Produces<Articulo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/articulos/dto", async (ArticuloMethods methods) =>
        {
            var articulos = await methods.ObtenerArticuloDTO();
            return Results.Ok(articulos);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen, Roles.UserAlmacen))
        .Produces<List<ArticuloDTO>>(StatusCodes.Status200OK)
        .Produces<ArticuloDTO>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/disenos-cascos", async (ArticuloMethods methods) =>
        {
            var disenos = await methods.ObtenerDisenosCascos();
            return Results.Ok(disenos);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen, Roles.UserAlmacen));
        app.MapGet("/disenos-cascos/{id}", async (string id, ArticuloMethods methods) =>
        {
            var diseno = await methods.ObtenerDisenoPorId(id);
            return diseno is not null ? Results.Ok(diseno) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen, Roles.UserAlmacen));
        app.MapGet("/disenos-cascos/nombre/{nombre}", async (string nombre, ArticuloMethods methods) =>
        {
            var id = await methods.ObtenerIdDiseno(nombre);
            return Results.Ok(id);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen, Roles.UserAlmacen));

        app.MapPost("/articulos", async (Articulo articulo, AuditoriaMethods auditoriaMethods, ArticuloMethods methods, HttpContext context) =>
        {          
            string id = await methods.Insertar(articulo);
            articulo.id = id;
            var usuario = context.User.Identity?.Name ?? "Desconocido";
            await auditoriaMethods.Registrar(usuario, "POST ARTICULO", $"/articulos/{articulo.id}", articulo.id, articulo);
            return Results.Created($"/articulos/{articulo.id}", articulo);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen))
        .Produces<Articulo>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);

        app.MapPost("/disenos-cascos", async (DisenoCasco diseno, AuditoriaMethods auditoriaMethods, ArticuloMethods methods, HttpContext context) =>
        {
            diseno.id = Guid.NewGuid().ToString();
            string id = await methods.InsertarDiseno(diseno);
            var usuario = context.User.Identity?.Name ?? "Desconocido";
            await auditoriaMethods.Registrar(usuario, "POST DISEÑO", $"/disenos-cascos/{diseno.id}", diseno.id, diseno);
            return Results.Created($"/disenos-cascos/{diseno.id}", diseno);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen))
        .Produces<DisenoCasco>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);

        app.MapPut("/articulos/{id}", async (string id, Articulo updatedArticulo, AuditoriaMethods auditoriaMethods, ArticuloMethods methods, HttpContext context) =>
        {
            var existing = await methods.ObtenerPorId(id) ?? throw new KeyNotFoundException("Artículo no encontrado");
            updatedArticulo.id = id;
            await methods.Actualizar(updatedArticulo);
            var refreshed = await methods.ObtenerPorId(id) ?? updatedArticulo;
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "PUT ARTICULO", $"/articulos/{id}", id, updatedArticulo);
            return Results.Ok(refreshed);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen))
        .Produces<Articulo>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapDelete("/articulos/{id}", async (string id, AuditoriaMethods auditoriaMethods, ArticuloMethods methods, HttpContext context) =>
        {
            var articulo = await methods.ObtenerPorId(id) ?? throw new KeyNotFoundException("Artículo no encontrado");
            await methods.Eliminar(id);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "DELETE ARTICULO", $"/articulos/{id}", id, articulo);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminAlmacen))
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
