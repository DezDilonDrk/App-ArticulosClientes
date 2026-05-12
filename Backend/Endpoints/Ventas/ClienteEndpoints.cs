using MTCore_AC.Entidades;
using System.Runtime.CompilerServices;
using Articulos_Backend.JWT;
using MTNegocios.Repositorios.Ventas;
using MTNegocios.MTEndpoints.Ventas;

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
            }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminVentas, Roles.UserVentas))
            .Produces<Cliente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/clientes", async (string? nombre, ClienteMethods methods) => {
            var clientes = string.IsNullOrEmpty(nombre)
                ? await methods.ObtenerClientes()
                : await methods.BuscarPorNombre(nombre);
            return Results.Ok(clientes);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminVentas, Roles.UserVentas)).Produces<List<Cliente>>(StatusCodes.Status200OK);
        app.MapPost("/clientes", async (Cliente cliente, ClienteMethods methods) =>
        {
            var existente = await methods.ObtenerPorDni(cliente.Dni);
            if (existente != null)
            {
                return Results.Conflict($"Ya existe un cliente con DNI {cliente.Dni}");
            }
            await methods.Insertar(cliente);
            return Results.Created($"/clientes/{cliente.Dni}", cliente);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminVentas))
        .Produces<Cliente>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/clientes/{dni}", async (string dni, Cliente clienteActualizado, ClienteMethods methods) =>
        {   
            var cliente = await methods.ObtenerPorDni(dni);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            clienteActualizado.Dni = dni;
            await methods.Actualizar(clienteActualizado);
            return Results.Ok(clienteActualizado);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminVentas))
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapDelete("/clientes/{dni}", async (string dni, ClienteMethods methods) =>
        {
            var cliente = await methods.ObtenerPorDni(dni);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            await methods.Eliminar(dni);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminVentas))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
        return app;
    }
}
