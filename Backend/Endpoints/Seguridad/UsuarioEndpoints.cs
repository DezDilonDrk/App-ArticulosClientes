using Microsoft.AspNetCore.Identity.Data;
using MTCore_AC.Entidades;
using MTCore_AC.DTO;
using static MTCore_AC.DTO.LoginDtos;
using MTNegocios.MTEndpoints.Seguridad;
using Articulos_Backend.JWT;
using MTNegocios.MTEndpoints.BBDD;

namespace Articulos_Backend.Endpoints.Seguridad;

public static class UsuarioEndpoints
{
    public static WebApplication MapUsuarioEndpoints(this WebApplication app)
    {
        app.MapGet("/usuarios", async (UsuarioMethods methods) =>
        {
            var usuarios = await methods.ObtenerUsuarios();
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<IEnumerable<Usuario>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuarios/{correoElectronico}/roles",  async (string correoElectronico, UsuarioMethods methods) =>
        {
            var roles = await methods.ObtenerRolesPorUsuario(correoElectronico);
            return Results.Ok(roles);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<IEnumerable<string>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuarios/correo/{correoElectronico}", async (string correoElectronico, UsuarioMethods methods) =>
        {
            var usuarios = await methods.ObtenerPorCorreo(correoElectronico);
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Usuario>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapGet("/usuarios/nombre/{nombre}", async (string nombre, UsuarioMethods methods) =>
        {
            var usuarios = await methods.ObtenerPorNombre(nombre);
            return usuarios is not null ? Results.Ok(usuarios) : Results.NotFound();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Usuario>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/usuarios",  async (Usuario usuario, UsuarioMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            await methods.Insertar(usuario);
            var usuarioc = context.User.Identity?.Name ?? "Desconocido";
            await auditoriaMethods.Registrar(usuarioc, "POST CLIENTE", $"/usuarios/correo/{usuario.CorreoElectronico}", usuario.CorreoElectronico, new {
                CorreoElectronico = usuario.CorreoElectronico,
                Nombre = usuario.Nombre
            });
            return Results.Created($"/usuarios/correo/{usuario.CorreoElectronico}", usuario);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces<Usuario>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapPost("/usuarios/login", async (MTCore_AC.DTO.LoginDtos.LoginRequest request, UsuarioMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            var jwtService = app.Services.GetRequiredService<JwtService>();

            var usuario = await methods.ObtenerPorCorreo(request.Email);
            //string currentServer = request.Server;

            if (usuario == null)
                return Results.Unauthorized();

            if (!BCrypt.Net.BCrypt.Verify(request.Password,usuario.Contrasena))
                return Results.Unauthorized();

            var roles = await methods.ObtenerRolesPorUsuario(usuario.CorreoElectronico);
            usuario.Contrasena = request.Password;
            var token = jwtService.GenerateToken(usuario.CorreoElectronico, roles, usuario);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "LOGIN", "/usuarios/login", null, new {
                Email = usuario.CorreoElectronico
            });
            Console.WriteLine("LOGIN EJECUTADO");
            return Results.Ok(new LoginResponse
            {
                token = token,
                Roles = roles,
                Usuario = usuario
            });
        });

        app.MapPut("/usuarios", async (Usuario usuario, UsuarioMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            await methods.Actualizar(usuario);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "PUT CLIENTE", $"/usuarios/correo/{usuario.CorreoElectronico}", usuario.CorreoElectronico);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapPut("/usuarios/{correo}/contrasena", async (string correo, CambiarContrasenaRequest request, UsuarioMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            await methods.ActualizarContrasena(correo, request.NuevaContrasena);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "PUT CONTRASEÑA", $"/usuarios/{correo}/contrasena", correo);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapPut("/usuarios/{correoElectronico}/roles", async (string correoElectronico, List<string> roles, UsuarioMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            await methods.ActualizarRoles(correoElectronico, roles);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "PUT USUARIO ROLES", $"/usuarios/{correoElectronico}/roles", correoElectronico, new
            {
                CorreoElectronico = correoElectronico,
                Roles = roles.ToArray()
            });
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapDelete("/usuarios/correo/{correoElectronico}", async (string correoElectronico, UsuarioMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            await methods.Eliminar(correoElectronico);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "DELETE USUARIO", $"/usuarios/correo/{correoElectronico}", correoElectronico, new {
                CorreoElectronico = correoElectronico
            });
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status400BadRequest);

        app.MapGet("/hostget", async (HttpContext context) =>
        {
            return context.Request.Host.Value;
        });

        return app;
    }
}
