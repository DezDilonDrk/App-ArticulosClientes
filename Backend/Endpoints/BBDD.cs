using Articulos_Backend.Scripts;
using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using System.Transactions;


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

                try
                {
                    await db.ExecuteAsync(SqlQueries.CrearTablaScript);
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
                        try
                        {
                            logger.LogInformation($"Ejecutando script: {nombre}");
                            var existe = await db.ExecuteScalarAsync<int>(
                            SqlQueries.ScriptExiste,
                            new { Nombre = nombre });

                            if (existe > 0)
                                continue;

                            await db.ExecuteAsync(script.script);

                            await db.ExecuteAsync(
                                SqlQueries.InsertScript,
                                new { Nombre = nombre });

                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, $"Error en script: {nombre}");
                            return Results.Problem($@"Script: {nombre}, Error: {ex.Message}, SQL: {script.script}
                            ");
                        }
                        
                    }

                    return Results.Ok(new DatabaseInitResponse
                    {
                        Message = "Base de datos inicializada",
                        Database = dbname,
                        Success = true
                    });
                }
                catch (Exception ex)
                {

                    logger.LogError(ex, "Error ejecutando scripts de base de datos");

                    return Results.Problem(ex.ToString());
                }

            }

        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad));

        app.MapPost("/database/migrate", async (DatabaseMigrateRequest request, IConfiguration config, ILogger<Program> logger) =>
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            var sourceDB = request.SourceDB;
            var targetDB = request.TargetDB;

            using var db = new SqlConnection(connectionString);
            await db.OpenAsync();

            try
            {
                logger.LogInformation($"Iniciando migración de datos de {sourceDB} a {targetDB}...");
                await db.ExecuteAsync($@"INSERT INTO {targetDB}.dbo.Usuarios (CorreoElectronico, NombreUsuario, Contrasena)
                                        SELECT s.CorreoElectronico, s.NombreUsuario, s.Contrasena
                                        FROM {sourceDB}.dbo.Usuarios s
                                        WHERE NOT EXISTS (
                                            SELECT 1 FROM {targetDB}.dbo.Usuarios t
                                            WHERE t.CorreoElectronico = s.CorreoElectronico
                                        );");

                await db.ExecuteAsync($@"SET IDENTITY_INSERT {targetDB}.dbo.Roles ON;
                                        INSERT INTO {targetDB}.dbo.Roles (Id, Nombre, Descripcion)
                                        SELECT s.Id, s.Nombre, s.Descripcion
                                        FROM {sourceDB}.dbo.Roles s
                                        WHERE NOT EXISTS (
                                            SELECT 1 FROM {targetDB}.dbo.Roles t
                                            WHERE t.Nombre = s.Nombre
                                        );
                                        SET IDENTITY_INSERT {targetDB}.dbo.Roles OFF;");
                await db.ExecuteAsync($@"SET IDENTITY_INSERT {targetDB}.dbo.Articulos ON;
                                        INSERT INTO {targetDB}.dbo.Articulos (Id, Nombre, Precio, Categoria, FechaCreacion, FechaActualizacion)
                                        SELECT s.Id, s.Nombre, s.Precio, s.Categoria, s.FechaCreacion, s.FechaActualizacion
                                        FROM {sourceDB}.dbo.Articulos s
                                        WHERE NOT EXISTS (
                                            SELECT 1 FROM {targetDB}.dbo.Articulos t
                                            WHERE t.Id = s.Id
                                        );
                                        SET IDENTITY_INSERT {targetDB}.dbo.Articulos OFF;");

                await db.ExecuteAsync($@"INSERT INTO {targetDB}.dbo.Clientes (Id, Dni, Nombre, Apellidos, Email, FechaCreacion, FechaModificacion)
                                        SELECT s.Id, s.Dni, s.Nombre, s.Apellidos, s.Email, s.FechaCreacion, s.FechaModificacion
                                        FROM {sourceDB}.dbo.Clientes s
                                        WHERE NOT EXISTS (
                                            SELECT 1 FROM {targetDB}.dbo.Clientes t
                                            WHERE t.Id = s.Id
                                        );");

                await db.ExecuteAsync($@"INSERT INTO {targetDB}.dbo.Configuraciones (correo_usuario, config_json)
                                        SELECT s.correo_usuario, s.config_json
                                        FROM {sourceDB}.dbo.Configuraciones s
                                        WHERE NOT EXISTS (
                                            SELECT 1 FROM {targetDB}.dbo.Configuraciones t
                                            WHERE t.correo_usuario = s.correo_usuario
                                        );");
                await db.ExecuteAsync($@"INSERT INTO {targetDB}.dbo.Pedidos (
                                        id_pedido, id_cliente, dni_cliente, nombre_cliente,
                                        metodo_pago, fecha_creacion, fecha_rectificacion,
                                        estado, porcentaje_impuestos, fecha_envio
                                    )
                                    SELECT 
                                        s.id_pedido, s.id_cliente, s.dni_cliente, s.nombre_cliente,
                                        s.metodo_pago, s.fecha_creacion, s.fecha_rectificacion,
                                        s.estado, s.porcentaje_impuestos, s.fecha_envio
                                    FROM {sourceDB}.dbo.Pedidos s
                                    WHERE NOT EXISTS (
                                        SELECT 1 FROM {targetDB}.dbo.Pedidos t
                                        WHERE t.id_pedido = s.id_pedido
                                    );");

                await db.ExecuteAsync($@"INSERT INTO {targetDB}.dbo.UsuarioRoles (UsuarioEmail, RolId)
                                        SELECT 
                                            s.UsuarioEmail,
                                            r_dest.Id
                                        FROM {sourceDB}.dbo.UsuarioRoles s
                                        JOIN {sourceDB}.dbo.Roles r_src 
                                            ON s.RolId = r_src.Id
                                        JOIN {targetDB}.dbo.Roles r_dest 
                                            ON r_dest.Nombre = r_src.Nombre
                                        WHERE NOT EXISTS (
                                            SELECT 1
                                            FROM {targetDB}.dbo.UsuarioRoles t
                                            WHERE t.UsuarioEmail = s.UsuarioEmail
                                              AND t.RolId = r_dest.Id
                                        );");

                await db.ExecuteAsync($@"INSERT INTO {targetDB}.dbo.Pedido_Articulos (id_pedido, id_articulo, cantidad, precio_unidad)
                                        SELECT s.id_pedido, s.id_articulo, s.cantidad, s.precio_unidad
                                        FROM {sourceDB}.dbo.Pedido_Articulos s
                                        WHERE NOT EXISTS (
                                            SELECT 1 FROM {targetDB}.dbo.Pedido_Articulos t
                                            WHERE t.id_pedido = s.id_pedido
                                              AND t.id_articulo = s.id_articulo
                                        );");
                return Results.Ok(new
                {
                    Message = $"Migración de datos de {sourceDB} a {targetDB} completada exitosamente"
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error durante migración de base de datos");
                return Results.Problem($"Error migrando datos: {ex.Message}");
            }
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad));

        return app;
    }


}
