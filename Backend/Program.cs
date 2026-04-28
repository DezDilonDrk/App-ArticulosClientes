using Articulos_Backend.Endpoints.Almacen;
using Articulos_Backend.Endpoints.Seguridad;
using Articulos_Backend.Endpoints.Ventas;
using Articulos_Backend.JWT;
using Articulos_Backend.Middleware;
using Articulos_Backend.Repositorios.Almacen;
using Articulos_Backend.Repositorios.Seguridad;
using Articulos_Backend.Repositorios.Ventas;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
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
var repositorioCliente = new ClienteRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioArticulo = new ArticuloRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioUsuario = new UsuarioRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioConfiguracion = new ConfiguracionRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioRol = new RolRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioUsuarioRol = new UsuarioRolRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioPedido = new PedidoRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
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
app.MapClienteEndpoints(repositorioCliente);
app.MapArticuloEndpoints(repositorioArticulo);
app.MapUsuarioEndpoints(repositorioUsuario);
app.MapConfiguracionEndpoints(repositorioConfiguracion);
app.MapPedidoEndpoints(repositorioPedido);
app.MapRolEndpoints(repositorioRol);
app.MapUsuarioRolEndpoints(repositorioUsuarioRol);
app.Run();