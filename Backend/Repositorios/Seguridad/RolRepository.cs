using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Repositorios.Seguridad
{
    public class RolRepository
    {
        private readonly string _connectionString;

        public RolRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<Rol> ObtenerRoles()
        {
            using (var db = Connection)
            {
                string sql = "SELECT Id, Nombre, Descripcion FROM Roles";
                return db.Query<Rol>(sql).ToList();
            }
        }

        public Rol ObtenerPorId(int id)
        {
            using (var db = Connection)
            {
                string sql = "SELECT Id, Nombre, Descripcion FROM Roles WHERE Id = @Id";
                return db.QueryFirstOrDefault<Rol>(sql, new { Id = id });
            }
        }

        public Rol ObtenerPorNombre(string nombre)
        {
            using (var db = Connection)
            {
                string sql = "SELECT Id, Nombre, Descripcion FROM Roles WHERE Nombre = @Nombre";
                return db.QueryFirstOrDefault<Rol>(sql, new { Nombre = nombre });
            }
        }

        public int Insertar(Rol rol)
        {
            using (var db = Connection)
            {
                string sql = "INSERT INTO Roles (Nombre, Descripcion) VALUES (@Nombre, @Descripcion); SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = db.QuerySingle<int>(sql, new { Nombre = rol.Nombre, Descripcion = rol.Descripcion });
                return id;
            }
        }

        public void Actualizar(Rol rol)
        {
            using (var db = Connection)
            {
                string sql = "UPDATE Roles SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id";
                db.Execute(sql, new { Nombre = rol.Nombre, Descripcion = rol.Descripcion, Id = rol.Id });
            }
        }

        public void Eliminar(int id)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM Roles WHERE Id = @Id";
                db.Execute(sql, new { Id = id });
            }
        }
    }
}
