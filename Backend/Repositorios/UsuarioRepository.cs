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

        public IEnumerable<string> ObtenerUsuarios()
        {
            using (var db = Connection)
            {
                string sql = "SELECT NombreUsuario FROM Usuarios";
                return db.Query<string>(sql).ToList();
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
                string sql = "INSERT INTO Usuarios (Correo, NombreUsuario, Contraseña) VALUES (@Correo, @NombreUsuario, @Contraseña)";
                db.Execute(sql, new { Correo = usuario.Correo, NombreUsuario = usuario.Nombre, Contraseña = usuario.Contrasena});
            }
        }

        public void Update(Usuario usuario) {
            using (var db = Connection)
            {
                string sql = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Contraseña = @Contraseña WHERE Correo = @Correo";
                db.Execute(sql, new { NombreUsuario = usuario.Nombre, Contraseña = usuario.Contrasena, Correo = usuario.Correo});
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
