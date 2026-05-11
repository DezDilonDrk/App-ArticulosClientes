using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MTCore_AC.Entidades;
using Microsoft.Extensions.Configuration;

namespace MTNegocios.Repositorios.Seguridad
{
    public class RolRepository
    {
        private readonly string _connectionString;

        public RolRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Rol>> ObtenerRoles()
        {
            using (var db = Connection)
            {
                string sql = "SELECT Id, Nombre, Descripcion FROM Roles";
                return (await db.QueryAsync<Rol>(sql)).ToList();
            }
        }

        public async Task<IEnumerable<Rol>> ObtenerNombreRoles()
        {
            using (var db = Connection)
            {
                string sql = "SELECT Nombre FROM Roles";
                return (await db.QueryAsync<Rol>(sql)).ToList();
            }
        }

        public async Task<Rol> ObtenerPorId(int id)
        {
            using (var db = Connection)
            {
                string sql = "SELECT Id, Nombre, Descripcion FROM Roles WHERE Id = @Id";
                return await db.QueryFirstOrDefaultAsync<Rol>(sql, new { Id = id });
            }
        }

        public async Task<Rol> ObtenerPorNombre(string nombre)
        {
            using (var db = Connection)
            {
                string sql = "SELECT Id, Nombre, Descripcion FROM Roles WHERE Nombre = @Nombre";
                return await db.QueryFirstOrDefaultAsync<Rol>(sql, new { Nombre = nombre });
            }
        }

        public async Task<int> Insertar(Rol rol)
        {
            using (var db = Connection)
            {
                string sql = "INSERT INTO Roles (Nombre, Descripcion) VALUES (@Nombre, @Descripcion); SELECT CAST(SCOPE_IDENTITY() as int);";
                var id = db.QuerySingle<int>(sql, new { Nombre = rol.Nombre, Descripcion = rol.Descripcion });
                return id;
            }
        }

        public async Task Actualizar(Rol rol)
        {
            using (var db = Connection)
            {
                string sql = "UPDATE Roles SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id";
                await db.ExecuteAsync(sql, new { Nombre = rol.Nombre, Descripcion = rol.Descripcion, Id = rol.Id });
            }
        }

        public async Task Eliminar(int id)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM Roles WHERE Id = @Id";
                await db.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
