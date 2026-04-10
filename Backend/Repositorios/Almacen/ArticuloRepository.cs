namespace Articulos_Backend.Repositorios.Almacen;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
public class ArticuloRepository
{
    private readonly string _connectionString;

    public ArticuloRepository(string connectionString)
    {
        _connectionString = connectionString;
        var x = new Cliente();
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public IEnumerable<Articulo> ObtenerArticulos()
    {
        using ( var db = Connection )
        {
            string sql = "SELECT Id, Nombre, Precio, Categoria, FechaCreacion, FechaActualizacion FROM Articulos";
            return db.Query<Articulo>(sql).ToList();
        }
    }

    public Articulo ObtenerPorId(int id)
    {
        
        using ( var db = Connection )
        {
            string sql = "SELECT * FROM Articulos WHERE Id = @Id";
            return db.QueryFirstOrDefault<Articulo>(sql, new { Id = id });
        }
    }

    public IEnumerable<Articulo> ObtenerPorNombre(string nombre)
    {
        using ( var db = Connection )
        {
            string sql = "SELECT * FROM Articulos WHERE Nombre LIKE @Nombre";
            return db.Query<Articulo>(sql, new { Nombre = $"%{nombre}%" });
        }
    }
    public Articulo ObtenerPorNombreExacto(string nombre)
    {
        using (var db = Connection)
        {
            string sql = "SELECT * FROM Articulos WHERE Nombre = @Nombre";
            return db.QueryFirstOrDefault<Articulo>(sql, new { Nombre = nombre });
        }
    }
    public int Insertar(Articulo articulo)
    {
        using var db = Connection;
        string sql = @"INSERT INTO Articulos (Nombre, Precio, Categoria, FechaCreacion) VALUES (@Nombre, @Precio, @Categoria, @FechaCreacion); SELECT CAST(SCOPE_IDENTITY() AS INT);";
        return db.QuerySingle<int>(sql, new
        {
            Nombre = articulo.nombre,
            Precio = articulo.precio,
            Categoria = articulo.categoria,
            FechaCreacion = DateTime.Now
        });
    }

    public void Actualizar(Articulo articulo)
    {
        using (var db = Connection)
        {
            string sql = "UPDATE Articulos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria, FechaActualizacion = @FechaActualizacion WHERE Id = @Id";
            db.Execute(sql, new { Nombre = articulo.nombre, Precio = articulo.precio, Categoria = articulo.categoria, FechaActualizacion = DateTime.Now, Id = articulo.id });
        }
    }

    public void Eliminar(int id)
    {
        using ( var db = Connection )
        {
            string sql = "DELETE FROM Articulos WHERE Id = @Id";
            db.Execute(sql, new { Id = id });
        }
    }
}
