using Articulos_Backend.Repositorios;
using ClientesASPNET;
using System.Runtime.CompilerServices;

namespace Articulos_Backend.Endpoints;

public static class ClienteEndpoints
{
     /* static List<Cliente> clientes = new List<Cliente>
     {
        new Cliente { Dni = "11446251A", Nombre = "Juan", Apellidos = "Fernandez Mendez", Email = "juans114@gmail.com" },
        new Cliente { Dni = "11446251B", Nombre = "Manolo", Apellidos = "Hernandez", Email = "manolete53@gmail.com" },
        new Cliente { Dni = "11446251C", Nombre = "Felipe", Apellidos = "Moreno", Email = "tomatitocherry@gmail.com" },
        new Cliente { Dni = "11446251D", Nombre = "Isabel", Apellidos = "Lopez Mendez", Email = "isaaab3l@gmail.com" },
        new Cliente { Dni = "11446251E", Nombre = "Maria José", Apellidos = "Casalins", Email = "mariajolamejor@gmail.com" },
        new Cliente { Dni = "11446251F", Nombre = "Francisco", Apellidos = "Martínez Díaz", Email = "paco@gmail.com" },
        new Cliente { Dni = "11446251G", Nombre = "José", Apellidos = "Pérez Garcia", Email = "josetrabajando@gmail.com" },
        new Cliente { Dni = "11446251H", Nombre = "Emilio", Apellidos = "Martínez García", Email = "emiliodepracticas@gmail.com" },
        new Cliente { Dni = "11446251I", Nombre = "Alejandro", Apellidos = "Hernandez Mendez", Email = "heiscalledalex@gmail.com" },
        new Cliente { Dni = "11446251J", Nombre = "Federico", Apellidos = "Fernandez", Email = "Federicoo26@gmail.com" },
        new Cliente { Dni = "11446252Z", Nombre = "María", Apellidos = "Díaz Blanco", Email = "mariadbisgood@gmail.com" }
     }; */
    public static WebApplication MapClienteEndpoints(this WebApplication app, ClienteRepository repo)
    {
        app.MapGet("/clientes/{dni}", (string dni) =>
            {
                var cliente = repo.ObtenerPorDni(dni);
                return cliente is not null
                    ? Results.Ok(cliente)
                    : Results.NotFound();
            })
            .Produces<Cliente>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/clientes", (string? nombre) => {
            var clientes = string.IsNullOrEmpty(nombre)
                ? repo.ObtenerClientes()
                : repo.BuscarPorNombre(nombre);
            return Results.Ok(clientes);
        }).Produces<List<Cliente>>(StatusCodes.Status200OK);
        app.MapPost("/clientes", (Cliente cliente) =>
        {
            var existente = repo.ObtenerPorDni(cliente.Dni);
            if (existente != null)
            {
                return Results.Conflict($"Ya existe un cliente con DNI {cliente.Dni}");
            }
            repo.Insertar(cliente);
            return Results.Created($"/clientes/{cliente.Dni}", cliente);
        })
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
        })
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
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
        return app;
    }

    /* private static List<Cliente> getClientes(string nombre) 
    {
        if (string.IsNullOrEmpty(nombre))
        {
            return clientes;
        }
        return clientes.Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
    } */
}
