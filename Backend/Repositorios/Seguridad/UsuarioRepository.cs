using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Repositorios.Seguridad
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            using (var db = Connection)
            {
                string sql = "SELECT CorreoElectronico AS CorreoElectronico, NombreUsuario AS Nombre, Contrasena AS Contrasena FROM Usuarios";
                return db.Query<Usuario>(sql).ToList();
            }
        }

        public Usuario ObtenerPorCorreo(string correoElectronico)
        {
            using (var db = Connection)
            {
                string sql = "SELECT CorreoElectronico AS CorreoElectronico, NombreUsuario AS Nombre, Contrasena AS Contrasena FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico";
                return db.QueryFirstOrDefault<Usuario>(sql, new { CorreoElectronico = correoElectronico });
            }
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            using (var db = Connection)
            {
                string sql = "SELECT CorreoElectronico AS CorreoElectronico, NombreUsuario AS Nombre, Contrasena AS Contrasena FROM Usuarios WHERE NombreUsuario = @Nombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new { Nombre = nombre });
            }
        }

        public List<string> ObtenerRolesPorUsuario(string correoElectronico)
        {
            using var db = Connection;

            string sql = @"SELECT r.Nombre FROM Roles r INNER JOIN UsuarioRoles ur ON ur.RolId = r.Id WHERE ur.UsuarioEmail = @Correo";

            return db.Query<string>(sql, new { Correo = correoElectronico }).ToList();
        }

        public void Insertar(Usuario usuario)
        {
            using (var db = Connection)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
                string sql = "INSERT INTO Usuarios (CorreoElectronico, NombreUsuario, Contrasena) VALUES (@CorreoElectronico, @NombreUsuario, @Contrasena)";
                var contrasenaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);
                db.Execute(sql, new { CorreoElectronico = usuario.CorreoElectronico, NombreUsuario = usuario.Nombre, Contrasena = contrasenaHash});
            }
        }

        public void Update(Usuario usuario) {
            using (var db = Connection)
            {
                string sql = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Contrasena = @Contrasena WHERE CorreoElectronico = @CorreoElectronico";
                db.Execute(sql, new { NombreUsuario = usuario.Nombre, Contrasena = usuario.Contrasena, CorreoElectronico = usuario.CorreoElectronico});
            }
        }

        public void ActualizarContrasena(string correoElectronico, string contrasena)
        {
            using (var db = Connection)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(contrasena);
                string sql = "UPDATE Usuarios SET Contrasena = @Contrasena WHERE CorreoElectronico = @CorreoElectronico";
                db.Execute(sql, new { Contrasena = hash, CorreoElectronico = correoElectronico });
            }
        }

        public void ActualizarRoles(string correoElectronico, List<string> roles)
        {
            using (var db = Connection)
            {
                string deleteSql = "DELETE FROM UsuarioRoles WHERE UsuarioEmail = @CorreoElectronico";
                db.Execute(deleteSql, new { CorreoElectronico = correoElectronico });
                string insertSql = "INSERT INTO UsuarioRoles (UsuarioEmail, RolId) VALUES (@CorreoElectronico, (SELECT Id FROM Roles WHERE Nombre = @RolNombre))";
                foreach (var rol in roles)
                {
                    db.Execute(insertSql, new { CorreoElectronico = correoElectronico, RolNombre = rol });
                }
            }
        }

        public void Eliminar(string correoElectronico)
        {
            using (var db = Connection)
            {
                string deleteRoles = "DELETE FROM UsuarioRoles WHERE UsuarioEmail = @CorreoElectronico";
                db.Execute(deleteRoles, new { CorreoElectronico = correoElectronico });

                string deleteUser = "DELETE FROM Usuarios WHERE CorreoElectronico = @CorreoElectronico";
                db.Execute(deleteUser, new { CorreoElectronico = correoElectronico });
            }
        }

    }
}
