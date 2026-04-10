
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
namespace Articulos_Backend.Repositorios.Ventas;

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
            string sql = "SELECT Dni, Nombre, Apellidos, Email, FechaCreacion, FechaModificacion FROM Clientes";
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
            string sql = @"SELECT Dni, Nombre, Apellidos, Email, FechaCreacion, FechaModificacion
                               FROM Clientes
                               WHERE Nombre LIKE @Nombre";

            return db.Query<Cliente>(sql, new { Nombre = $"%{nombre}%" }).ToList();
        }
    }
    public void Insertar(Cliente cliente)
    {
        using (var db = Connection)
        {
            string sql = @"INSERT INTO Clientes (Dni, Nombre, Apellidos, Email, FechaCreacion)
                           VALUES (@Dni, @Nombre, @Apellidos, @Email, @FechaCreacion)";
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
                                   Email = @Email,
                                   FechaModificacion = @FechaModificacion    
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
