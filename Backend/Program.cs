using Articulos_Backend.Endpoints.Almacen;
using Articulos_Backend.Endpoints.Seguridad;
using Articulos_Backend.Endpoints.Ventas;
using Articulos_Backend.Endpoints;
using Articulos_Backend.JWT;
using Articulos_Backend.Middleware;
using MTNegocios.Repositorios.Almacen;
using MTNegocios.Repositorios.Seguridad;
using MTNegocios.Repositorios.Ventas;
using MTNegocios.Repositorios;
using MTNegocios.MTEndpoints.Seguridad;
using MTNegocios.MTEndpoints.Almacen;
using MTNegocios.MTEndpoints.Ventas;
using MTNegocios.MTEndpoints.BBDD;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/log.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7
    ).CreateLogger();
builder.Host.UseSerilog();
var key = Encoding.UTF8.GetBytes("CLAVE_SECRETA_SECRETOSA_PORFAVOR_FUNCIONA_SOCORRO");
builder.WebHost.UseUrls("http://0.0.0.0:5000");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JwtService>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ArticuloRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ConfiguracionRepository>();
builder.Services.AddScoped<RolRepository>();
builder.Services.AddScoped<UsuarioRolRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<ClienteMethods>();
builder.Services.AddScoped<ArticuloMethods>();
builder.Services.AddScoped<UsuarioMethods>();
builder.Services.AddScoped<ConfiguracionMethods>();
builder.Services.AddScoped<PedidoMethods>();
builder.Services.AddScoped<RolMethods>();
builder.Services.AddScoped<UsuarioRolMethods>();
builder.Services.AddScoped<MigrationBBDD>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<AuditoriaRepository>();
builder.Services.AddScoped<AuditoriaMethods>();
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapClienteEndpoints();
app.MapArticuloEndpoints();
app.MapUsuarioEndpoints();
app.MapConfiguracionEndpoints();
app.MapPedidoEndpoints();
app.MapRolEndpoints();
app.MapUsuarioRolEndpoints();
app.MapBBDDEndpoints();
app.Run();