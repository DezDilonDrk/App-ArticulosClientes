using Articulos_Backend.Repositorios;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints;

public static class UsuarioEndpoints
{
    public static WebApplication MapUsuarioEndpoints(this WebApplication app, UsuarioRepository repo)
    {
        app.MapGet("/usuarios", () =>
        {
            var usuarios = repo.ObtenerUsuarios();
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        })
        .Produces<IEnumerable<Usuario>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuarios/correo/{correo}", (string correo) =>
        {
            var usuarios = repo.ObtenerPorCorreo(correo);
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        })
        .Produces<Usuario>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuarios/nombre/{nombre}", (string nombre) =>
        {
            var usuarios = repo.ObtenerPorNombre(nombre);
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        })
        .Produces<Usuario>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/usuarios", (Usuario usuario) =>
        {
            repo.Insertar(usuario);
            return Results.Created($"/usuarios/correo/{usuario.Correo}", usuario);
        })
        .Produces<Usuario>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapPut("/usuarios", (Usuario usuario) =>
        {
            repo.Update(usuario);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapDelete("/usuarios/correo/{correo}", (string correo) =>
        {
            repo.Eliminar(correo);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        return app;
    }
}
