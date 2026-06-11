using MTCore_AC.DTO;
using MTNegocios.Repositorios.Ventas;
using MTCore_AC.Entidades;

namespace MTNegocios.Scripts;

public class PAK_2026611000000_InsertClientes: Script
{
    public override async Task Execute(string connectionString)
    {
        var clienteRepo = new ClienteRepository(connectionString);

        var clientes = new List<Cliente>
        {
            new Cliente
            {
                Dni = "12345678A",
                Nombre = "Juan",
                Apellidos = "Pérez García",
                Email = "juan.perez@example.com",
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            },
            new Cliente
            {
                Dni = "87654321B",
                Nombre = "María",
                Apellidos = "López Fernández",
                Email = "maria.lopez@example.com",
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            },
            new Cliente
            {
                Dni = "11223344C",
                Nombre = "Carlos",
                Apellidos = "Sánchez Martínez",
                Email = "carlos.sanchez@example.com",
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            },
            new Cliente
            {
                Dni = "44332211D",
                Nombre = "Ana",
                Apellidos = "Gómez Rodríguez",
                Email = "ana.gomez@example.com",
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            },
            new Cliente
            {
                Dni = "55667788E",
                Nombre = "Luis",
                Apellidos = "Fernández López",
                Email = "luis.fernandez@example.com",
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            }
        };

        foreach (var cliente in clientes)
        {
            await clienteRepo.Insertar(cliente);
        }
    }
}
