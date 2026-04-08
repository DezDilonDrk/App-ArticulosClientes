
using Articulos_Backend.Endpoints;
using Articulos_Backend.JWT;
using Articulos_Backend.Middleware;
using Articulos_Backend.Repositorios;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JwtService>();
var repositorioCliente = new ClienteRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioArticulo = new ArticuloRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioUsuario = new UsuarioRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
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
app.MapClienteEndpoints(repositorioCliente);
app.MapArticuloEndpoints(repositorioArticulo);
app.MapUsuarioEndpoints(repositorioUsuario);
app.MapPedidoEndpoints(repositorioPedido);
app.MapRolEndpoints(repositorioRol);
app.MapUsuarioRolEndpoints(repositorioUsuarioRol);
app.Run();