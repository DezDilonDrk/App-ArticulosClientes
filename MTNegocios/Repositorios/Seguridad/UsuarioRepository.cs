using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
using Microsoft.Extensions.Configuration;

namespace MTNegocios.Repositorios.Seguridad
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            using (var db = Connection)
            {
                string sql = "SELECT CorreoElectronico AS CorreoElectronico, NombreUsuario AS Nombre, Contrasena AS Contrasena FROM Usuarios";
                return (await db.QueryAsync<Usuario>(sql)).ToList();
            }
        }

        public async Task<Usuario> ObtenerPorCorreo(string correoElectronico)
        {
            using (var db = Connection)
            {
                string sql = "SELECT CorreoElectronico AS CorreoElectronico, NombreUsuario AS Nombre, Contrasena AS Contrasena FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico";
                return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { CorreoElectronico = correoElectronico });
            }
        }

        public async Task<Usuario> ObtenerPorNombre(string nombre)
        {
            using (var db = Connection)
            {
                string sql = "SELECT CorreoElectronico AS CorreoElectronico, NombreUsuario AS Nombre, Contrasena AS Contrasena FROM Usuarios WHERE NombreUsuario = @Nombre";
                return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Nombre = nombre });
            }
        }

        public async Task<List<string>> ObtenerRolesPorUsuario(string correoElectronico)
        {
            using var db = Connection;

            string sql = @"SELECT r.Nombre FROM Roles r INNER JOIN UsuarioRoles ur ON ur.RolId = r.Id WHERE ur.UsuarioEmail = @Correo";

            return (await db.QueryAsync<string>(sql, new { Correo = correoElectronico })).ToList();
        }

        public async Task Insertar(Usuario usuario)
        {
            using (var db = Connection)
            {
                string sql = "INSERT INTO Usuarios (CorreoElectronico, NombreUsuario, Contrasena) VALUES (@CorreoElectronico, @NombreUsuario, @Contrasena)";
                var contrasenaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
                await db.ExecuteAsync(sql, new { CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.Nombre, Contrasena = contrasenaHash});
            }
        }

        public async Task Update(Usuario usuario) {
            using (var db = Connection)
            {
                string sql = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Contrasena = @Contrasena WHERE CorreoElectronico = @CorreoElectronico";
                await db.ExecuteAsync(sql, new { NombreUsuario = usuario.Nombre, Contrasena = usuario.Contrasena, CorreoElectronico = usuario.CorreoElectronico});
            }
        }

        public async Task ActualizarContrasena(string correoElectronico, string contrasena)
        {
            using (var db = Connection)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(contrasena);
                string sql = "UPDATE Usuarios SET Contrasena = @Contrasena WHERE CorreoElectronico = @CorreoElectronico";
                await db.ExecuteAsync(sql, new { Contrasena = hash, CorreoElectronico = correoElectronico });
            }
        }

        public async Task ActualizarRoles(string correoElectronico, List<string> roles)
        {
            using (var db = Connection)
            {
                string deleteSql = "DELETE FROM UsuarioRoles WHERE UsuarioEmail = @CorreoElectronico";
                await db.ExecuteAsync(deleteSql, new { CorreoElectronico = correoElectronico });
                string insertSql = "INSERT INTO UsuarioRoles (UsuarioEmail, RolId) VALUES (@CorreoElectronico, (SELECT Id FROM Roles WHERE Nombre = @RolNombre))";
                foreach (var rol in roles)
                {
                    await db.ExecuteAsync(insertSql, new { CorreoElectronico = correoElectronico, RolNombre = rol });
                }
            }
        }

        public async Task Eliminar(string correoElectronico)
        {
            using (var db = Connection)
            {
                string deleteRoles = "DELETE FROM UsuarioRoles WHERE UsuarioEmail = @CorreoElectronico";
                await db.ExecuteAsync(deleteRoles, new { CorreoElectronico = correoElectronico });

                string deleteUser = "DELETE FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico";
                await db.ExecuteAsync(deleteUser, new { CorreoElectronico = correoElectronico });
            }
        }

    }
}
