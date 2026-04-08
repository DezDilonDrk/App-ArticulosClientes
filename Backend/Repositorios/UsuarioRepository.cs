using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Repositorios
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
                string sql = "SELECT CorreoElectronico AS Correo, NombreUsuario AS Nombre, Contrasena AS Contrasena FROM Usuarios";
                return db.Query<Usuario>(sql).ToList();
            }
        }

        public Usuario ObtenerPorCorreo(string correo)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Usuarios WHERE Correo = @Correo";
                return db.QueryFirstOrDefault<Usuario>(sql, new { Correo = correo });
            }
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Usuarios WHERE NombreUsuario = @Nombre";
                return db.QueryFirstOrDefault<Usuario>(sql, new { Nombre = nombre });
            }
        }

        public void Insertar(Usuario usuario)
        {
            using (var db = Connection)
            {
                string sql = "INSERT INTO Usuarios (Correo, NombreUsuario, Contrasena) VALUES (@Correo, @NombreUsuario, @Contrasena)";
                db.Execute(sql, new { Correo = usuario.Correo, NombreUsuario = usuario.Nombre, Contrasena = usuario.Contrasena});
            }
        }

        public void Update(Usuario usuario) {
            using (var db = Connection)
            {
                string sql = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Contrasena = @Contrasena WHERE Correo = @Correo";
                db.Execute(sql, new { NombreUsuario = usuario.Nombre, Contrasena = usuario.Contrasena, Correo = usuario.Correo});
            }
        }

        public void Eliminar(string correo)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM Usuarios WHERE Correo = @Correo";
                db.Execute(sql, new { Correo = correo });
            }
        }


    }
}
