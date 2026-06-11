using NUnit.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Extensions.Logging.Abstractions;
using MTNegocios.MTEndpoints.BBDD;
using MTNegocios.ConexionDB;


namespace MTNegocios.ScriptTest;

[TestFixture]
public class DatabaseTests
{
    static string databaseName = $"DB_{Guid.NewGuid():N}";
    private string connectionString = $"Server=localhost;Database={databaseName};Trusted_Connection=true;TrustServerCertificate=true;";
    private MigrationBBDD _migration;

    [OneTimeSetUp]
    public async Task Init()
    {

        _migration = new MigrationBBDD();

        var logger = NullLogger<Program>.Instance;

        var resultado = await _migration.InitDatabase(
            databaseName,
            logger);

        Assert.That(resultado.Success, Is.True);
    }

    [Test]
    public async Task BaseDeDatos_Creada()
    {
        using var connection =
            new SqlConnection(
                "Server=localhost;Database=master;Trusted_Connection=true;TrustServerCertificate=true;");

        await connection.OpenAsync();

        int existe = await connection.ExecuteScalarAsync<int>(
            @$"SELECT COUNT(*)
          FROM sys.databases
          WHERE name = '{databaseName}'");

        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public void MostrarConnectionString()
    {
        var builder = new Builder();
        builder.builder.InitialCatalog = databaseName;

        Console.WriteLine(builder.builder.ConnectionString);

        Assert.Pass();
    }

    [Test]
    public async Task Tabla_ScriptsEjecutados_Creada()
    {
        var builder = new Builder();
        builder.builder.InitialCatalog = databaseName;

        using var db = new SqlConnection(builder.builder.ConnectionString);
        await db.OpenAsync();
        var existe = await db.ExecuteScalarAsync<int>(@"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ScriptEjecutados'");
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Comprobar_ScriptsEjecutados()
    {
        var builder = new Builder();
        builder.builder.InitialCatalog = databaseName;
        using var db = new SqlConnection(builder.builder.ConnectionString);
        await db.OpenAsync();
        var total = await db.ExecuteScalarAsync<int>(@"SELECT COUNT(*) FROM ScriptEjecutados");
        Assert.That(total, Is.GreaterThan(0));
    }

    [Test]
    public async Task Tabla_Roles()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Roles'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Rol_Admin_Seguridad_Existe()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM Roles WHERE Nombre = 'ADMIN_SEGURIDAD'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Tabla_Usuarios()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Usuario_Admin_Existe()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = 'Administrador'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Usuario_Admin_Tiene_Rol_Admin()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"
            SELECT COUNT(*)
            FROM Usuarios u
            JOIN UsuarioRoles ur ON u.CorreoElectronico = ur.UsuarioEmail
            JOIN Roles r ON ur.RolId = r.Id
            WHERE u.NombreUsuario = 'Administrador' AND r.Nombre = 'ADMIN_SEGURIDAD'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Tabla_DisenosCascos()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DisenoCascos'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Tabla_Articulos()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Articulos'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Tabla_Clientes()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Tabla_Auditoria()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Auditoria'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [Test]
    public async Task Existen_Articulos()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM Articulos";
        int count = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(count, Is.GreaterThan(0));
    }

    [Test]
    public async Task Existe_FK_Articulos_Diseno()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        string sql = @"SELECT COUNT(*) FROM sys.foreign_keys WHERE name = 'FK_Articulos_DisenoCascos'";
        int existe = await connection.ExecuteScalarAsync<int>(sql);
        Assert.That(existe, Is.EqualTo(1));
    }

    [OneTimeTearDown]
    public async Task Cleanup()
    {
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
            IF DB_ID('{databaseName}') IS NOT NULL
            BEGIN
                ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                DROP DATABASE [{databaseName}];
            END
            """;
            await master.ExecuteAsync(sql);
        }
    }
    
}
