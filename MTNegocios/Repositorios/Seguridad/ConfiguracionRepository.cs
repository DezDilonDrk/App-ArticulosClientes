using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.Entidades;
using System.Data;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace MTNegocios.Repositorios.Seguridad
{
    public class ConfiguracionRepository
    {
        private readonly string _connectionString;
        public ConfiguracionRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);
        public async Task<ConfiguracionModel?> ObtenerConfiguracionPorCorreo(string correo)
        {
            using (var db = Connection)
            {
                string sql = "SELECT config_json FROM Configuraciones WHERE correo_usuario = @correo_usuario";
                var json = await db.QueryFirstOrDefaultAsync<string>(sql, new { correo_usuario = correo });
                if (json == null)
                {
                    return null;
                }
                return JsonSerializer.Deserialize<ConfiguracionModel>(json);
            }
        }
        public async Task GuardarConfiguracionPorCorreo(string id, ConfiguracionModel configuracion, string correo)
        {
            using var db = Connection;
            string json = JsonSerializer.Serialize(configuracion);
            const string updateSql = @"UPDATE Configuraciones
                                       SET config_json = @json
                                       WHERE correo_usuario = @correo";
            int filas = await db.ExecuteAsync(updateSql, new { json, correo});
            if (filas == 0)
            {
                const string insertSql = @"INSERT INTO Configuraciones
                                           (id_configuracion, correo_usuario, config_json)
                                           VALUES (@id, @correo, @json)";
                await db.ExecuteAsync(insertSql, new { id, correo, json });
            }
        }
    }
}
