using MTCore_AC.Entidades;
using System.Runtime.CompilerServices;
using Articulos_Backend.JWT;
using MTNegocios.Repositorios.Ventas;
using MTNegocios.MTEndpoints.Ventas;
using MTNegocios.MTEndpoints.BBDD;

namespace Articulos_Backend.Endpoints.Ventas;

public static class ClienteEndpoints
{
    public static WebApplication MapClienteEndpoints(this WebApplication app)
    {
        app.MapGet("/clientes/{dni}", async (string dni, ClienteMethods methods) =>
            {
                var result = await methods.ObtenerPorDni(dni);
                return result is not null
                    ? Results.Ok(result)
                    : Results.NotFound();
            }).RequireAuthorization(Roles.VentasAdminOUser)
            .Produces<Cliente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/clientes", async (string? nombre, ClienteMethods methods) => {
            var clientes = string.IsNullOrEmpty(nombre)
                ? await methods.ObtenerClientes()
                : await methods.BuscarPorNombre(nombre);
            return Results.Ok(clientes);
        }).RequireAuthorization(Roles.VentasAdminOUser).Produces<List<Cliente>>(StatusCodes.Status200OK);
        app.MapPost("/clientes", async (Cliente cliente, ClienteMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            var existente = await methods.ObtenerPorDni(cliente.Dni);
            if (existente != null)
            {
                return Results.Conflict($"Ya existe un cliente con DNI {cliente.Dni}");
            }
            await methods.Insertar(cliente);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "POST CLIENTE", $"/clientes/{cliente.Dni}", cliente.Dni, new {
                Dni = cliente.Dni,
                Nombre = cliente.Nombre
            });
            return Results.Created($"/clientes/{cliente.Dni}", cliente);
        }).RequireAuthorization(Roles.AdminVentas)
        .Produces<Cliente>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/clientes/{dni}", async (string dni, Cliente clienteActualizado, ClienteMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {   
            var cliente = await methods.ObtenerPorDni(dni);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            clienteActualizado.Dni = dni;
            await methods.Actualizar(clienteActualizado);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "PUT CLIENTE", $"/clientes/{dni}", dni, new {
                Dni = dni,
                Nombre = clienteActualizado.Nombre
            });
            return Results.Ok(clienteActualizado);
        }).RequireAuthorization(Roles.AdminVentas)
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapDelete("/clientes/{dni}", async (string dni, ClienteMethods methods, AuditoriaMethods auditoriaMethods, HttpContext context) =>
        {
            var cliente = await methods.ObtenerPorDni(dni);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            await methods.Eliminar(dni);
            await auditoriaMethods.Registrar(context.User.Identity?.Name ?? "Desconocido", "DELETE CLIENTE", $"/clientes/{dni}", dni, new {
                Dni = dni
            });
            return Results.NoContent();
        }).RequireAuthorization(Roles.AdminVentas)
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
        return app;
    }
}
