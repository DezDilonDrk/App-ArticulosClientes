using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;


namespace Articulos_Backend.Endpoints;

public static class BBDD
{
    public static WebApplication MapBBDDEndpoints(this WebApplication app)
    {
        app.MapGet("/database/scripts", async (IConfiguration config, ILogger<Program> logger) =>
        {
            try
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                using var db = new SqlConnection(connectionString);
                await db.OpenAsync();
                
                var ejecutados = (await db.QueryAsync<(string NombreScript, DateTime fechaEjecucion)>(SqlQueries.SelectScript)).ToList();
                
                var basePath = AppContext.BaseDirectory;
                var scriptsPath = Path.Combine(basePath, "Scripts");

                if (!Directory.Exists(scriptsPath))
                {
                    logger.LogError("La carpeta Scripts no existe");
                    return Results.Problem("Carpeta de scripts no encontrada");
                }

                var archivos = Directory.GetFiles(scriptsPath, "*.sql").Select(Path.GetFileName).OrderBy(x => x).ToList();

                var resultado = archivos.Select(nombre =>
                {
                    var scriptEjecutado = ejecutados.FirstOrDefault(e => e.NombreScript == nombre);

                    return new ScriptEstado
                    {
                        Nombre = nombre,
                        Ejecutado = scriptEjecutado.NombreScript != null,
                        Fecha = scriptEjecutado.NombreScript != null ? scriptEjecutado.fechaEjecucion : null
                    };
                });

                return Results.Ok(resultado);

            }catch (Exception ex)
            {
                logger.LogError(ex, "Error obteniendo estado de scripts");
                return Results.Problem("Error al obtener scripts");
            }
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad));

        app.MapPost("/database/init", async (DatabaseInitRequest request, IConfiguration config, ILogger<Program> logger) =>
        {
            var dbname = request.DbName;
            var connectionString = config.GetConnectionString("DefaultConnection");
            var builderCs = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = dbname
            };
            var masterBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = "master"
            };

            logger.LogInformation("Iniciando creación de base de datos...");

            using (var master = new SqlConnection(masterBuilder.ConnectionString))
            {
                await master.OpenAsync();
                var sql = $@"IF DB_ID('{dbname}') IS NULL
                             BEGIN
                                CREATE DATABASE [{dbname}]
                             END";
                await master.ExecuteAsync(sql);
            }

            logger.LogInformation("Base de datos verificada/creada correctamente");

            using (var db = new SqlConnection(builderCs.ConnectionString))
            {
                await db.OpenAsync();

                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        await db.ExecuteAsync(SqlQueries.CrearTablaScript,transaction: transaction);
                        var basePath = AppContext.BaseDirectory;
                        var scriptsPath = Path.Combine(basePath, "Scripts");
                        if (!Directory.Exists(scriptsPath))
                        {
                            logger.LogError("La carpeta Scripts no existe");
                            return Results.Problem("Carpeta de scripts no encontrada");
                        }
                        var scripts = Directory.GetFiles(scriptsPath, "*.sql")
                       .OrderBy(x => x)
                       .ToList();

                        foreach (var scriptPath in scripts)
                        {
                            var nombre = Path.GetFileName(scriptPath);

                            var existe = await db.ExecuteScalarAsync<int>(
                                SqlQueries.ScriptExiste,
                                new { Nombre = nombre }, transaction);

                            if (existe > 0)
                                continue;

                            var sql = await File.ReadAllTextAsync(scriptPath);

                            await db.ExecuteAsync(sql, transaction: transaction);

                            await db.ExecuteAsync(
                                SqlQueries.InsertScript,
                                new { Nombre = nombre }, transaction);
                        }
                        transaction.Commit();

                        return Results.Ok(new DatabaseInitResponse
                        {
                            Message = "Base de datos inicializada",
                            Database = dbname,
                            Sucess = true
                        });
                    }catch (Exception ex)
                    {
                        transaction.Rollback();

                        logger.LogError(ex, "Error ejecutando scripts de base de datos");

                        return Results.Problem(ex.ToString());
                    }
                    
                }
            }

        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad));

        return app;
    }


}
