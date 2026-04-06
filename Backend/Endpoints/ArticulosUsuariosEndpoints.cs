using Articulos_Backend.Repositorios;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints;

public static class ArticulosUsuariosEndpoints
{
    public static WebApplication MapArticulosUsuariosEndpoints(this WebApplication app, ArticulosUsuariosRepository repo)
    {
        app.MapGet("/articulos-usuarios", () =>
        {
            var list = repo.ObtenerAll();
            return list is not null ? Results.Ok(list) : Results.NotFound();
        })
        .Produces<IEnumerable<ArticuloUsuario>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/articulos-usuarios/usuario/{email}", (string email) =>
        {
            var articulos = repo.ObtenerArticulosPorUsuario(email);
            return Results.Ok(articulos);
        })
        .Produces<IEnumerable<Articulo>>(StatusCodes.Status200OK);

        app.MapGet("/articulos-usuarios/articulo/{id:int}", (int id) =>
        {
            var usuarios = repo.ObtenerPorArticulo(id);
            return Results.Ok(usuarios);
        })
        .Produces<IEnumerable<ArticuloUsuario>>(StatusCodes.Status200OK);

        app.MapPost("/articulos-usuarios", (ArticuloUsuario relacion) =>
        {
            repo.Insertar(relacion.ArticuloId, relacion.UsuarioEmail);
            return Results.Created($"/articulos-usuarios/{relacion.ArticuloId}/{relacion.UsuarioEmail}", relacion);
        })
        .Produces<ArticuloUsuario>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);

        app.MapDelete("/articulos-usuarios/{articuloId:int}/{email}", (int articuloId, string email) =>
        {
            var existente = repo.ObtenerPorArticuloYUsuario(articuloId, email);
            if (existente is null) return Results.NotFound();
            repo.Eliminar(articuloId, email);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
