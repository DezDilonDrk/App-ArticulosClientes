using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
using Microsoft.Extensions.Configuration;

namespace MTNegocios.Repositorios.Seguridad
{
    public class UsuarioRolRepository
    {
        private readonly string _connectionString;

        public UsuarioRolRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<UsuarioRol>> ObtenerAll()
        {
            using (var db = Connection)
            {
                string sql = "SELECT RolId, UsuarioEmail FROM UsuarioRoles";
                return (await db.QueryAsync<UsuarioRol>(sql)).ToList();
            }
        }

        public async Task<UsuarioRol?> ObtenerPorRolYUsuario(int rolId, string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = "SELECT RolId, UsuarioEmail FROM UsuarioRoles WHERE RolId = @RolId AND UsuarioEmail = @UsuarioEmail";
                return await db.QueryFirstOrDefaultAsync<UsuarioRol>(sql, new { RolId = rolId, UsuarioEmail = usuarioEmail });
            }
        }

        public async Task<IEnumerable<UsuarioRol>> ObtenerPorRol(int rolId)
        {
            using (var db = Connection)
            {
                string sql = "SELECT RolId, UsuarioEmail FROM UsuarioRoles WHERE RolId = @RolId";
                return (await db.QueryAsync<UsuarioRol>(sql, new { RolId = rolId })).ToList();
            }
        }

        public async Task<IEnumerable<UsuarioRol>> ObtenerPorUsuario(string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = "SELECT RolId, UsuarioEmail FROM UsuarioRoles WHERE UsuarioEmail = @UsuarioEmail";
                return (await db.QueryAsync<UsuarioRol>(sql, new { UsuarioEmail = usuarioEmail })).ToList();
            }
        }

        public async Task<IEnumerable<Rol>> ObtenerRolesPorUsuario(string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = @"SELECT r.Id, r.Nombre
                               FROM Roles r
                               INNER JOIN UsuarioRoles ur ON r.Id = ur.RolId
                               WHERE ur.UsuarioEmail = @Email";
                return (await db.QueryAsync<Rol>(sql, new { Email = usuarioEmail })).ToList();
            }
        }
        public async Task Eliminar(int rolId, string usuarioEmail)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM UsuarioRoles WHERE RolId = @RolId AND UsuarioEmail = @UsuarioEmail";
                await db.ExecuteAsync(sql, new { RolId = rolId, UsuarioEmail = usuarioEmail });
            }
        }
    }
}
