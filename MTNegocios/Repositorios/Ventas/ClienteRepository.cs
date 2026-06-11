
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
using Microsoft.Extensions.Configuration;

namespace MTNegocios.Repositorios.Ventas;

public class ClienteRepository
{
    private readonly string _connectionString;
    public ClienteRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);
    public async Task<List<Cliente>> ObtenerClientes()
    {
        using (var db = Connection)
        {
            string sql = "SELECT Id, Dni, Nombre, Apellidos, Email, FechaCreacion, FechaModificacion FROM Clientes";
            return (await db.QueryAsync<Cliente>(sql)).ToList();
        }
    }
    public async Task<Cliente?> ObtenerPorDni(string dni)
    {
        using (var db = Connection)
        {
            string sql = "SELECT * FROM Clientes WHERE Dni = @Dni";
            return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { Dni = dni });
        }
    }
    public async Task<List<Cliente>> BuscarPorNombre(string nombre)
    {
        using (var db = Connection)
        {
            string sql = @"SELECT Id, Dni, Nombre, Apellidos, Email, FechaCreacion, FechaModificacion
                               FROM Clientes
                               WHERE Nombre LIKE @Nombre";

            return (await db.QueryAsync<Cliente>(sql, new { Nombre = $"%{nombre}%" })).ToList();
        }
    }
    public async Task Insertar(Cliente cliente)
    {
        using (var db = Connection)
        {
            string sql = @"INSERT INTO Clientes (Id, Dni, Nombre, Apellidos, Email, FechaCreacion)
                           VALUES (@Id, @Dni, @Nombre, @Apellidos, @Email, @FechaCreacion)";
            await db.ExecuteAsync(sql, cliente);
        }
    }
    public async Task Actualizar(Cliente cliente)
    {
        using (var db = Connection)
        {
            string sql = @"UPDATE Clientes
                               SET Nombre = @Nombre,
                                   Apellidos = @Apellidos,
                                   Email = @Email,
                                   FechaModificacion = @FechaModificacion    
                               WHERE Dni = @Dni";

            await db.ExecuteAsync(sql, cliente);
        }
    }
    public async Task Eliminar(string dni)
    {
        using (var db = Connection)
        {
            string sql = "DELETE FROM Clientes WHERE Dni = @Dni";

            await db.ExecuteAsync(sql, new { Dni = dni });
        }
    }
}
