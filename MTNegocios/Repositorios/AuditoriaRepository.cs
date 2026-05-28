using Dapper;
using MTCore_AC.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MTNegocios.Repositorios;

public class AuditoriaRepository
{
    private readonly string _connectionString;
    public AuditoriaRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public async Task Insertar(Auditoria auditoria)
    {
        using (var dbConnection = Connection)
        {
            var sql = @"INSERT INTO Auditoria (Id, Usuario, Accion, Entidad, EntidadId, Fecha, Datos)
                        VALUES (@Id, @Usuario, @Accion, @Entidad, @EntidadId, @Fecha, @Datos)";
            await dbConnection.ExecuteAsync(sql, new
            {
                Id = auditoria.Id,
                Usuario = auditoria.Usuario,
                Accion = auditoria.Accion,
                Entidad = auditoria.Entidad,
                EntidadId = auditoria.EntidadId,
                Fecha = auditoria.Fecha,
                Datos = auditoria.Datos
            });

        }
    }

    public async Task<IEnumerable<Auditoria>> ObtenerAuditorias()
    {
        using (var dbConnection = Connection)
        {
            var sql = "SELECT * FROM Auditoria ORDER BY Fecha DESC";
            return await dbConnection.QueryAsync<Auditoria>(sql);
        }
    }
}
