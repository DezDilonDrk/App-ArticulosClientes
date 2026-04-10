using Articulos_Backend.JWT;
using Microsoft.AspNetCore.Identity.Data;
using MTCore_AC.Entidades;
using MTCore_AC.DTO;
using static MTCore_AC.DTO.LoginDtos;
using Articulos_Backend.Repositorios.Seguridad;

namespace Articulos_Backend.Endpoints.Seguridad;

public static class UsuarioEndpoints
{
    public static WebApplication MapUsuarioEndpoints(this WebApplication app, UsuarioRepository repo)
    {
        app.MapGet("/usuarios", () =>
        {
            var usuarios = repo.ObtenerUsuarios();
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminUsuarios))
        .Produces<IEnumerable<Usuario>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuarios/correo/{correoElectronico}", (string correoElectronico) =>
        {
            var usuarios = repo.ObtenerPorCorreo(correoElectronico);
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminUsuarios))
        .Produces<Usuario>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuarios/nombre/{nombre}", (string nombre) =>
        {
            var usuarios = repo.ObtenerPorNombre(nombre);
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminUsuarios))
        .Produces<Usuario>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/usuarios", (Usuario usuario) =>
        {
            repo.Insertar(usuario);
            return Results.Created($"/usuarios/correo/{usuario.CorreoElectronico}", usuario);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminUsuarios))
        .Produces<Usuario>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapPost("/usuarios/login", (MTCore_AC.DTO.LoginDtos.LoginRequest request) =>
        {
            var jwtService = app.Services.GetRequiredService<JwtService>();

            var usuario = repo.ObtenerPorCorreo(request.Email);

            if (usuario == null)
                return Results.Unauthorized();

            if (!BCrypt.Net.BCrypt.Verify(request.Password, usuario.Contrasena))
                return Results.Unauthorized();

            var roles = repo.ObtenerRolesPorUsuario(usuario.CorreoElectronico);
            var token = jwtService.GenerateToken(usuario.CorreoElectronico, roles);

            return Results.Ok(new LoginResponse
            {
                Token = token,
                Roles = roles,
                Usuario = usuario
            });
        });

        app.MapPut("/usuarios", (Usuario usuario) =>
        {
            repo.Update(usuario);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminUsuarios))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapDelete("/usuarios/correo/{correoElectronico}", (string correoElectronico) =>
        {
            repo.Eliminar(correoElectronico);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminUsuarios))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        return app;
    }
}
