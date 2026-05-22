using Microsoft.Data.SqlClient;
using Dapper;
using MTCore_AC.DTO;
using MTNegocios.ConexionDB;
using Microsoft.Extensions.Logging;
using MTNegocios.MTEndpoints.Almacen;
using MTNegocios.MTEndpoints.Seguridad;
using MTNegocios.MTEndpoints.Ventas;
using MTCore_AC.Entidades;

namespace MTNegocios.MTEndpoints.BBDD;

public class SeedService
{
    private readonly string _connectionString;
    private readonly ArticuloMethods _aMethods;
    private readonly ClienteMethods _cMethods;
    private readonly UsuarioMethods _uMethods;
    public SeedService(IConfiguration configuration, ArticuloMethods aMethods, ClienteMethods cMethods, UsuarioMethods uMethods)
    {
        _aMethods = aMethods;
        _cMethods = cMethods;
        _uMethods = uMethods;
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IResult> SeedDatabase(DatabaseSeedRequest request, List<Articulo> articulos, List<Cliente> clientes, List<Usuario> usuarios, ILogger logger)
    {
        try
        {
            using var db = new SqlConnection(_connectionString);
            await db.OpenAsync();

            foreach (var articulo in articulos)
            { 
                await _aMethods.Insertar(articulo);
            }

            foreach (var cliente in clientes) { 
                await _cMethods.Insertar(cliente);
            }

            foreach (var usuario in usuarios)
            {
                await _uMethods.Insertar(usuario);
            }

            return Results.Ok(new { Message = "Datos generados correctamente" });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al generar datos de prueba");
            return Results.Problem("Ocurrió un error al generar los datos de prueba");
        }
    }
}
