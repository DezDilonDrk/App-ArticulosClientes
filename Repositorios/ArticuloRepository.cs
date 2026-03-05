namespace Articulos_Backend.Repositorios;

using Articulos_Backend.Articulos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

public class ArticuloRepository
{
    private readonly string _connectionString;

    public ArticuloRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public IEnumerable<Articulo> ObtenerArticulos()
    {
        using ( var db = Connection )
        {
            string sql = "SELECT Id, Nombre, Precio, Categoria FROM Articulos";
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
    public void Insertar(Articulo articulo)
    {
        using ( var db = Connection )
        {
            string sql = "INSERT INTO Articulos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)";
            db.Execute(sql, articulo);
        }
    }

    public void Actualizar(Articulo articulo)
    {
        using ( var db = Connection )
        {
            string sql = "UPDATE Articulos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria WHERE Id = @Id";
            db.Execute(sql, articulo);
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
