using Articulos_Backend.Scripts;
using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;


namespace Articulos_Backend.Endpoints;

public static class BBDD
{
    public static WebApplication MapBBDDEndpoints(this WebApplication app)
    {
        app.MapGet("/database/scripts/{dbname}", async (string dbname, IConfiguration config, ILogger<Program> logger) =>
        {
            try
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                var builder = new SqlConnectionStringBuilder(connectionString)
                {
                    InitialCatalog = dbname
                };
                using var db = new SqlConnection(builder.ConnectionString);
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
            if (string.IsNullOrWhiteSpace(dbname) || dbname.Any(c => !char.IsLetterOrDigit(c) && c != '_'))
            {
                return Results.BadRequest("Nombre de base de datos inválido");
            }

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
                        var assembly = typeof(PAK_2026429000000_CreateUsuarios).Assembly;

                        var scripts = assembly
                            .GetTypes()
                            .Where(t => typeof(Script).IsAssignableFrom(t) && !t.IsAbstract)
                            .Select(t => (Script)Activator.CreateInstance(t)!)
                            .OrderBy(s => s.GetType().Name)
                            .ToList();
                        scripts = scripts.OrderBy(s => s.GetType().Name).ToList();
                        foreach (var script in scripts)
                        {
                            var nombre = script.GetType().Name;

                            var existe = await db.ExecuteScalarAsync<int>(
                                SqlQueries.ScriptExiste,
                                new { Nombre = nombre }, transaction);

                            if (existe > 0)
                                continue;

                            await db.ExecuteAsync(script.script, transaction: transaction);

                            await db.ExecuteAsync(
                                SqlQueries.InsertScript,
                                new { Nombre = nombre }, transaction);
                        }
                        transaction.Commit();

                        return Results.Ok(new DatabaseInitResponse
                        {
                            Message = "Base de datos inicializada",
                            Database = dbname,
                            Success = true
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
