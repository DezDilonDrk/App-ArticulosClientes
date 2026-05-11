using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using System.Transactions;
using MTNegocios.ConexionDB;
using MTNegocios.MTEndpoints.BBDD;
using Microsoft.AspNetCore.Mvc;


namespace Articulos_Backend.Endpoints;

public static class BBDD
{
    static Builder builder = new Builder();
    public static WebApplication MapBBDDEndpoints(this WebApplication app)
    {
        app.MapGet("/database/scripts/{dbname}", async (string dbname, [FromServices] MigrationBBDD service, [FromServices] ILogger<Program> logger) =>
        {
            try
            {
                var result = await service.ExecutedScripts(dbname, logger);
                return Results.Ok(result);

            }catch (Exception ex)
            {
                logger.LogError(ex, "Error obteniendo estado de scripts");
                return Results.Problem("Error al obtener scripts");
            }
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad));

        app.MapPost("/database/init", async (DatabaseInitRequest request, [FromServices] MigrationBBDD service, [FromServices] ILogger<Program> logger) =>
        {
            try
            {
                var result = await service.InitDatabase(request.DbName, logger);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error inicializando DB");
                return Results.Problem(ex.Message);
            }
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad));

        app.MapPost("/database/migrate", async (DatabaseMigrateRequest request, IConfiguration config, ILogger<Program> logger) =>
        {
            var connectionString = config.GetConnectionString(builder.builder.ConnectionString);
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
                logger.LogError(ex, "Error durante migración de base de dato    s");
                return Results.Problem($"Error migrando datos: {ex.Message}");
            }
        }).RequireAuthorization(policy => policy.RequireRole(Roles.AdminSeguridad));

        return app;
    }


}
