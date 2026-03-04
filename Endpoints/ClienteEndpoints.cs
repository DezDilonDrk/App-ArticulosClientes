using ClientesASPNET;

namespace Articulos_Backend.Endpoints;

public static class ClienteEndpoints
{
    public static WebApplication MapClienteEndpoints(this WebApplication app)
    {
        List<Cliente> clientes = new List<Cliente>
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
        };


        app.MapGet("/clientes", () =>
        {
            return clientes;
        });

        app.MapGet("/clientes/dni/{dni}", (string dni) =>
        {
            var cliente = clientes.FirstOrDefault(c => c.Dni == dni);
            return cliente is not null
                ? Results.Ok(cliente)
                : Results.NotFound();
        });

        app.MapGet("/clientes/nombre/{nombre}", (string nombre) => {
            var resultado = clientes
                .Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return resultado.Any()
                ? Results.Ok(resultado)
                : Results.NotFound();
        });


        app.MapPost("/clientes", (Cliente cliente) =>
        {
            if (clientes.Any(c => c.Dni == cliente.Dni || c.Email == cliente.Email))
            {
                return Results.Conflict($"Un cliente con DNI {cliente.Dni} o Email {cliente.Email} ya existe");
            }
            clientes.Add(cliente);
            return Results.Created($"/clientes/dni/{cliente.Dni}", cliente);
        });


        app.MapPut("/clientes/dni/{dni}", (string dni, Cliente clienteActualizado) =>
        {
            var clienteExistente = clientes.FirstOrDefault(c => c.Dni == dni);

            if (clienteExistente is null)
            {
                return Results.NotFound();
            }

            if (clientes.Any(c => c.Email == clienteActualizado.Email && c.Dni != dni))
            {
                return Results.Conflict($"Otro cliente con Email {clienteActualizado.Email} ya existe");
            }

            clienteExistente.Nombre = clienteActualizado.Nombre;
            clienteExistente.Apellidos = clienteActualizado.Apellidos;
            clienteExistente.Email = clienteActualizado.Email;

            return Results.Ok(clienteExistente);
        });


        app.MapDelete("/clientes/dni/{dni}", (string dni) =>
        {
            var cliente = clientes.FirstOrDefault(c => c.Dni == dni);

            if (cliente is null)
            {
                return Results.NotFound();
            }

            clientes.Remove(cliente);

            return Results.NoContent();
        });


        return app;
    }
}
