namespace MTNegocios.Repositorios.Almacen;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
using Microsoft.Extensions.Configuration;
public class ArticuloRepository
{
    private readonly string _connectionString;
    public ArticuloRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
        var x = new Cliente();
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public async Task<IEnumerable<Articulo>> ObtenerArticulos()
    {
        using ( var db = Connection )
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, d.Nombre AS DisenoCasco, a.FechaCreacion, a.FechaActualizacion FROM Articulos a JOIN DisenoCascos d ON a.IdDisenoCasco = d.Id";
            return (await db.QueryAsync<Articulo>(sql)).ToList();
        }
    }

    public async Task<Articulo> ObtenerPorId(string id)
    {
        
        using ( var db = Connection )
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, d.Nombre AS DisenoCasco, a.FechaCreacion, a.FechaActualizacion FROM Articulos a JOIN DisenoCascos d ON a.IdDisenoCasco = d.Id WHERE a.Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Articulo>(sql, new { Id = id });
        }
    }

    public async Task<IEnumerable<Articulo>> ObtenerPorNombre(string nombre)
    {
        using ( var db = Connection )
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, d.Nombre AS DisenoCasco, a.FechaCreacion, a.FechaActualizacion FROM Articulos a JOIN DisenoCascos d ON a.IdDisenoCasco = d.Id WHERE a.Nombre LIKE @Nombre";
            return await db.QueryAsync<Articulo>(sql, new { Nombre = $"%{nombre}%" });
        }
    }
    public async Task<Articulo> ObtenerPorNombreExacto(string nombre)
    {
        using (var db = Connection)
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, d.Nombre AS DisenoCasco, a.FechaCreacion, a.FechaActualizacion FROM Articulos a JOIN DisenoCascos d ON a.IdDisenoCasco = d.Id WHERE a.Nombre = @Nombre";
            return await db.QueryFirstOrDefaultAsync<Articulo>(sql, new { Nombre = nombre });
        }
    }
    public async Task<string> Insertar(Articulo articulo)
    {
        using var db = Connection;
        string sql = @"INSERT INTO Articulos (Id, Nombre, Precio, Categoria, FechaCreacion) VALUES (@Id, @Nombre, @Precio, @Categoria, @FechaCreacion); SELECT CAST(SCOPE_IDENTITY() AS INT);";
        return await db.QuerySingleAsync<string>(sql, new
        {
            Id = articulo.id,
            Nombre = articulo.nombre,
            Precio = articulo.precio,
            Categoria = articulo.categoria,
            FechaCreacion = DateTime.Now
        });
    }

    public async Task Actualizar(Articulo articulo)
    {
        using (var db = Connection)
        {
            string sql = "UPDATE Articulos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria, FechaActualizacion = @FechaActualizacion WHERE Id = @Id";
            await db.ExecuteAsync(sql, new { Nombre = articulo.nombre, Precio = articulo.precio, Categoria = articulo.categoria, FechaActualizacion = DateTime.Now, Id = articulo.id });
        }
    }

    public async Task Eliminar(string id)
    {
        using ( var db = Connection )
        {
            string sql = "DELETE FROM Articulos WHERE Id = @Id";
            await db.ExecuteAsync(sql, new { Id = id });
        }
    }
}
