using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Repositorios;

public class ArticulosUsuariosRepository
{
    private readonly string _connectionString;

    public ArticulosUsuariosRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public IEnumerable<ArticuloUsuario> ObtenerAll()
    {
        using (var db = Connection)
        {
            string sql = "SELECT articulo_id AS ArticuloId, usuario_email AS UsuarioEmail FROM Articulos_Usuarios";
            return db.Query<ArticuloUsuario>(sql).ToList();
        }
    }

    public ArticuloUsuario? ObtenerPorArticuloYUsuario(int articuloId, string usuarioEmail)
    {
        using (var db = Connection)
        {
            string sql = "SELECT articulo_id AS ArticuloId, usuario_email AS UsuarioEmail FROM Articulos_Usuarios WHERE articulo_id = @ArticuloId AND usuario_email = @UsuarioEmail";
            return db.QueryFirstOrDefault<ArticuloUsuario>(sql, new { ArticuloId = articuloId, UsuarioEmail = usuarioEmail });
        }
    }

    public IEnumerable<ArticuloUsuario> ObtenerPorArticulo(int articuloId)
    {
        using (var db = Connection)
        {
            string sql = "SELECT articulo_id AS ArticuloId, usuario_email AS UsuarioEmail FROM Articulos_Usuarios WHERE articulo_id = @ArticuloId";
            return db.Query<ArticuloUsuario>(sql, new { ArticuloId = articuloId }).ToList();
        }
    }

    public IEnumerable<ArticuloUsuario> ObtenerPorUsuario(string usuarioEmail)
    {
        using (var db = Connection)
        {
            string sql = "SELECT articulo_id AS ArticuloId, usuario_email AS UsuarioEmail FROM Articulos_Usuarios WHERE usuario_email = @UsuarioEmail";
            return db.Query<ArticuloUsuario>(sql, new { UsuarioEmail = usuarioEmail }).ToList();
        }
    }

    public IEnumerable<MTCore_AC.Entidades.Articulo> ObtenerArticulosPorUsuario(string usuarioEmail)
    {
        using (var db = Connection)
        {
            string sql = @"SELECT a.Id, a.Nombre, a.Precio, a.Categoria, a.FechaCreacion, a.FechaActualizacion
                           FROM Articulos a
                           INNER JOIN Articulos_Usuarios au ON a.Id = au.articulo_id
                           WHERE au.usuario_email = @Email";
            return db.Query<MTCore_AC.Entidades.Articulo>(sql, new { Email = usuarioEmail }).ToList();
        }
    }

    public void Insertar(int articuloId, string usuarioEmail)
    {
        using (var db = Connection)
        {
            var existente = ObtenerPorArticuloYUsuario(articuloId, usuarioEmail);
            if (existente != null)
            {
                throw new InvalidOperationException($"La relación artículo-usuario ya existe: {articuloId} - {usuarioEmail}");
            }

            string sql = "INSERT INTO Articulos_Usuarios (articulo_id, usuario_email) VALUES (@ArticuloId, @UsuarioEmail)";
            db.Execute(sql, new { ArticuloId = articuloId, UsuarioEmail = usuarioEmail });
        }
    }

    public void Eliminar(int articuloId, string usuarioEmail)
    {
        using (var db = Connection)
        {
            string sql = "DELETE FROM Articulos_Usuarios WHERE articulo_id = @ArticuloId AND usuario_email = @UsuarioEmail";
            db.Execute(sql, new { ArticuloId = articuloId, UsuarioEmail = usuarioEmail });
        }
    }
}
