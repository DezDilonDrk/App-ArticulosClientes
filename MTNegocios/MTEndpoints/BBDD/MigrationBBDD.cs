using MTNegocios.Scripts;
using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.DTO;
using MTNegocios.ConexionDB;

namespace MTNegocios.MTEndpoints.BBDD;

public class MigrationBBDD
{
    private readonly Builder _builder;
    private readonly IConfiguration _config;

    public MigrationBBDD()
    {
        _builder = new Builder();
    }

    public async Task<DatabaseInitResponse> InitDatabase(
        string dbname,
        ILogger logger)
    {
        _builder.builder.InitialCatalog = dbname;

        var masterBuilder = new Builder
        {
            builder =
            {
                InitialCatalog = "master"
            }
        };

        using (var master = new SqlConnection(masterBuilder.builder.ConnectionString))
        {
            await master.OpenAsync();

            var sql = $"""
            IF DB_ID('{dbname}') IS NULL
            BEGIN
                CREATE DATABASE [{dbname}]
            END
            """;

            await master.ExecuteAsync(sql);
        }

        using (var db = new SqlConnection(_builder.builder.ConnectionString))
        {
            await db.OpenAsync();

            await db.ExecuteAsync(SqlQueries.CrearTablaScript);

            var assembly = typeof(PAK_2026429000000_CreateUsuarios).Assembly;

            var scripts = assembly
                .GetTypes()
                .Where(t => typeof(Script).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (Script)Activator.CreateInstance(t)!)
                .OrderBy(s => s.GetType().Name)
                .ToList();

            foreach (var script in scripts)
            {
                var nombre = script.GetType().Name;

                logger.LogInformation($"Ejecutando script: {nombre}");

                var existe = await db.ExecuteScalarAsync<int>(
                    SqlQueries.ScriptExiste,
                    new { Nombre = nombre });

                if (existe > 0)
                    continue;

                if (!string.IsNullOrWhiteSpace(script.script))
                {
                    await db.ExecuteAsync(script.script);
                }

                await script.Execute(_builder.builder.ConnectionString);

                await db.ExecuteAsync(
                    SqlQueries.InsertScript,
                    new { Nombre = nombre });
            }
        }

        return new DatabaseInitResponse
        {
            Message = "Base de datos inicializada",
            Database = dbname,
            Success = true
        };
    }

    public async Task<IEnumerable<ScriptEstado>> ExecutedScripts(string dbname, ILogger logger)
    {
        _builder.builder.InitialCatalog = dbname;

        using (var db = new SqlConnection(_builder.builder.ConnectionString))
        {
            try
            {
                await db.OpenAsync();
                var ejecutados = (await db.QueryAsync<(string NombreScript, DateTime fechaEjecucion)>(SqlQueries.SelectScript)).ToList();
                var scripts = typeof(PAK_2026429000000_CreateUsuarios).Assembly
                .GetTypes()
                .Where(t => typeof(Script).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => t.Name)
                .OrderBy(x => x)
                .ToList();

                var resultado = scripts.Select(nombre =>
                {
                    var scriptEjecutado = ejecutados
                        .FirstOrDefault(e => e.NombreScript == nombre);

                    return new ScriptEstado
                    {
                        Nombre = nombre,
                        Ejecutado = scriptEjecutado.NombreScript != null,
                        Fecha = scriptEjecutado.NombreScript != null
                            ? scriptEjecutado.fechaEjecucion
                            : null
                    };
                });

                return resultado;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al obtener los scripts ejecutados");
                return Enumerable.Empty<ScriptEstado>();
            }
        }
    }
}
