using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Repositorios
{
    public class UsuarioRolRepository
    {
        private readonly string _connectionString;

        public UsuarioRolRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<UsuarioRol> ObtenerAll()
        {
            using (var db = Connection)
            {
                string sql = "SELECT rol_id AS RolId, usuario_email AS UsuarioEmail FROM UsuarioRoles";
                return db.Query<UsuarioRol>(sql).ToList();
            }
        }

        public UsuarioRol? ObtenerPorRolYUsuario(int rolId, string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = "SELECT rol_id AS RolId, usuario_email AS UsuarioEmail FROM UsuarioRoles WHERE rol_id = @RolId AND usuario_email = @UsuarioEmail";
                return db.QueryFirstOrDefault<UsuarioRol>(sql, new { RolId = rolId, UsuarioEmail = usuarioEmail });
            }
        }

        public IEnumerable<UsuarioRol> ObtenerPorRol(int rolId)
        {
            using (var db = Connection)
            {
                string sql = "SELECT rol_id AS RolId, usuario_email AS UsuarioEmail FROM UsuarioRoles WHERE rol_id = @RolId";
                return db.Query<UsuarioRol>(sql, new { RolId = rolId }).ToList();
            }
        }

        public IEnumerable<UsuarioRol> ObtenerPorUsuario(string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = "SELECT rol_id AS RolId, usuario_email AS UsuarioEmail FROM UsuarioRoles WHERE usuario_email = @UsuarioEmail";
                return db.Query<UsuarioRol>(sql, new { UsuarioEmail = usuarioEmail }).ToList();
            }
        }

        public IEnumerable<Rol> ObtenerRolesPorUsuario(string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = @"SELECT r.Id, r.Nombre
                               FROM Roles r
                               INNER JOIN UsuarioRoles ur ON r.Id = ur.rol_id
                               WHERE ur.usuario_email = @Email";
                return db.Query<Rol>(sql, new { Email = usuarioEmail }).ToList();
            }
        }
        public void Eliminar(int rolId, string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM UsuarioRoles WHERE rol_id = @RolId AND usuario_email = @UsuarioEmail";
                db.Execute(sql, new { RolId = rolId, UsuarioEmail = usuarioEmail });
            }
        }
    }
}
