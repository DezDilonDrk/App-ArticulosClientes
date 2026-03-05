using ClientesASPNET;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Articulos_Backend.Repositorios;

public class ClienteRepository
{
    private readonly string _connectionString;
    public ClienteRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    private IDbConnection Connection => new SqlConnection(_connectionString);
    public List<Cliente> ObtenerClientes()
    {
        using (var db = Connection)
        {
            string sql = "SELECT Dni, Nombre, Apellidos, Email FROM Clientes";
            return db.Query<Cliente>(sql).ToList();
        }
    }
    public Cliente ObtenerPorDni(string dni)
    {
        using (var db = Connection)
        {
            string sql = "SELECT * FROM Clientes WHERE Dni = @Dni";
            return db.QueryFirstOrDefault<Cliente>(sql, new { Dni = dni });
        }
    }
    public List<Cliente> BuscarPorNombre(string nombre)
    {
        using (var db = Connection)
        {
            string sql = @"SELECT Dni, Nombre, Apellidos, Email
                               FROM Clientes
                               WHERE Nombre LIKE @Nombre";

            return db.Query<Cliente>(sql, new { Nombre = $"%{nombre}%" }).ToList();
        }
    }
    public void Insertar(Cliente cliente)
    {
        using (var db = Connection)
        {
            string sql = @"INSERT INTO Clientes (Dni, Nombre, Apellidos, Email)
                           VALUES (@Dni, @Nombre, @Apellidos, @Email)";
            db.Execute(sql, cliente);
        }
    }
    public void Actualizar(Cliente cliente)
    {
        using (var db = Connection)
        {
            string sql = @"UPDATE Clientes
                               SET Nombre = @Nombre,
                                   Apellidos = @Apellidos,
                                   Email = @Email
                               WHERE Dni = @Dni";

            db.Execute(sql, cliente);
        }
    }
    public void Eliminar(string dni)
    {
        using (var db = Connection)
        {
            string sql = "DELETE FROM Clientes WHERE Dni = @Dni";

            db.Execute(sql, new { Dni = dni });
        }
    }
}
