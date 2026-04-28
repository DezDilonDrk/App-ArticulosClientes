using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.Entidades;
using System.Data;
using System.Text.Json;

namespace Articulos_Backend.Repositorios.Seguridad
{
    public class ConfiguracionRepository
    {
        private readonly string _connectionString;
        public ConfiguracionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);
        public ConfiguracionModel ObtenerConfiguracionPorCorreo(string correo)
        {
            using (var db = Connection)
            {
                string sql = "SELECT config_json FROM Configuraciones WHERE correo_usuario = @correo_usuario";
                var json = db.QueryFirstOrDefault<string>(sql, new { correo_usuario = correo });
                if (json == null)
                {
                    return null;
                }
                return JsonSerializer.Deserialize<ConfiguracionModel>(json);
            }
        }
        public void GuardarConfiguracionPorCorreo(string id, ConfiguracionModel configuracion, string correo)
        {
            using var db = Connection;
            string json = JsonSerializer.Serialize(configuracion);
            const string updateSql = @"UPDATE Configuraciones
                                       SET config_json = @json
                                       WHERE correo_usuario = @correo";
            int filas = db.Execute(updateSql, new { json, correo});
            if (filas == 0)
            {
                const string insertSql = @"INSERT INTO Configuraciones
                                           (id_configuracion, correo_usuario, config_json)
                                           VALUES (@id, @correo, @json)";
                db.Execute(insertSql, new { id, correo, json });
            }
        }
    }
}
