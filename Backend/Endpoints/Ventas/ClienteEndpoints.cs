using MTCore_AC.Entidades;
using System.Runtime.CompilerServices;
using Articulos_Backend.JWT;
using Articulos_Backend.Repositorios.Ventas;

namespace Articulos_Backend.Endpoints.Ventas;

public static class ClienteEndpoints
{
    public static WebApplication MapClienteEndpoints(this WebApplication app, ClienteRepository repo)
    {
        app.MapGet("/clientes/{dni}", (string dni) =>
            {
                var cliente = repo.ObtenerPorDni(dni);
                return cliente is not null
                    ? Results.Ok(cliente)
                    : Results.NotFound();
            }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminClientes, Roles.UserClientes))
            .Produces<Cliente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/clientes", (string? nombre) => {
            var clientes = string.IsNullOrEmpty(nombre)
                ? repo.ObtenerClientes()
                : repo.BuscarPorNombre(nombre);
            return Results.Ok(clientes);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminClientes, Roles.UserClientes)).Produces<List<Cliente>>(StatusCodes.Status200OK);
        app.MapPost("/clientes", (Cliente cliente) =>
        {
            var existente = repo.ObtenerPorDni(cliente.Dni);
            if (existente != null)
            {
                return Results.Conflict($"Ya existe un cliente con DNI {cliente.Dni}");
            }
            repo.Insertar(cliente);
            return Results.Created($"/clientes/{cliente.Dni}", cliente);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminClientes))
        .Produces<Cliente>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/clientes/{dni}", (string dni, Cliente clienteActualizado) =>
        {
            var cliente = repo.ObtenerPorDni(dni);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            clienteActualizado.Dni = dni;
            repo.Actualizar(clienteActualizado);
            return Results.Ok(clienteActualizado);
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminClientes))
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapDelete("/clientes/{dni}", (string dni) =>
        {
            var cliente = repo.ObtenerPorDni(dni);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            repo.Eliminar(dni);
            return Results.NoContent();
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminClientes))
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
        return app;
    }
}
