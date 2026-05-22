namespace MTNegocios.Repositorios.Almacen;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
using Microsoft.Extensions.Configuration;
using MTCore_AC.DTO;
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
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, a.FechaCreacion, a.IdDisenoCasco, a.FechaActualizacion FROM Articulos a ";
            return (await db.QueryAsync<Articulo>(sql)).ToList();
        }
    }

    public async Task<Articulo> ObtenerPorId(string id)
    {
        
        using ( var db = Connection )
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, a.FechaCreacion, a.IdDisenoCasco, a.FechaActualizacion FROM Articulos a WHERE a.Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Articulo>(sql, new { Id = id });
        }
    }

    public async Task<IEnumerable<Articulo>> ObtenerPorNombre(string nombre)
    {
        using ( var db = Connection )
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, a.FechaCreacion, a.IdDisenoCasco, a.FechaActualizacion FROM Articulos a WHERE a.Nombre LIKE @Nombre";
            return await db.QueryAsync<Articulo>(sql, new { Nombre = $"%{nombre}%" });
        }
    }
    public async Task<Articulo> ObtenerPorNombreExacto(string nombre)
    {
        using (var db = Connection)
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, a.FechaCreacion, a.IdDisenoCasco, a.FechaActualizacion FROM Articulos a WHERE a.Nombre = @Nombre";
            return await db.QueryFirstOrDefaultAsync<Articulo>(sql, new { Nombre = nombre });
        }
    }

    public async Task<IEnumerable<ArticuloDTO>> ObtenerArticuloDTO()
    {
        using (var db = Connection)
        {
            string sql = "SELECT a.Id, a.Nombre, a.Precio, a.Categoria, d.Nombre AS DisenoCasco, a.FechaCreacion, a.FechaActualizacion FROM Articulos a LEFT JOIN DisenoCascos d ON a.IdDisenoCasco = d.Id";
            return (await db.QueryAsync<ArticuloDTO>(sql)).ToList();
        }
    }

    public async Task<IEnumerable<DisenoCasco>> ObtenerDisenosCascos()
    {
        using (var db = Connection)
        {
            string sql = "SELECT Id, Nombre, Descripcion FROM DisenoCascos";
            return await db.QueryAsync<DisenoCasco>(sql);
        }
    }

    public async Task<DisenoCasco> ObtenerDisenoPorId(string id)
    {
        using (var db = Connection)
        {
            string sql = "SELECT Id, Nombre, Descripcion FROM DisenoCascos WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<DisenoCasco>(sql, new { Id = id });
        }
    }
    public async Task<string> ObtenerIdDiseno(string nombre)
    {
        using(var db = Connection)
        {
            string sql = "SELECT Id FROM DisenoCascos WHERE Nombre = @Nombre";
            return await db.QueryFirstOrDefaultAsync<string>(sql, new { Nombre = nombre });
        }
    }

    public async Task<string> Insertar(Articulo articulo)
    {
        using var db = Connection;
        string sql = @"INSERT INTO Articulos (Id, Nombre, Precio, Categoria, IdDisenoCasco, FechaCreacion) VALUES (@Id, @Nombre, @Precio, @Categoria, @IdDisenoCasco, @FechaCreacion); SELECT CAST(SCOPE_IDENTITY() AS INT);";
        return await db.QuerySingleAsync<string>(sql, new
        {
            Id = articulo.id,
            Nombre = articulo.Nombre,
            Precio = articulo.Precio,
            Categoria = articulo.Categoria,
            IdDisenoCasco = articulo.IdDisenoCasco,
            FechaCreacion = DateTime.Now
        });
    }

    public async Task<string> InsertarDiseno(DisenoCasco diseno)
    {
        using (var db = Connection)
        {
            string sql = @"INSERT INTO DisenoCascos (Id, Nombre, Descripcion) VALUES (@Id, @Nombre, @Descripcion);";
            await db.ExecuteAsync(sql, new
            {
                Id = diseno.id,
                Nombre = diseno.nombre,
                Descripcion = diseno.descripcion
            });
            return diseno.id;
        }
    }

    public async Task Actualizar(Articulo articulo)
    {
        using (var db = Connection)
        {
            string sql = "UPDATE Articulos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria, IdDisenoCasco = @IdDisenoCasco, FechaActualizacion = @FechaActualizacion WHERE Id = @Id";
            await db.ExecuteAsync(sql, new { Nombre = articulo.Nombre, Precio = articulo.Precio, Categoria = articulo.Categoria, IdDisenoCasco = articulo.IdDisenoCasco, FechaActualizacion = DateTime.Now, Id = articulo.id });
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
