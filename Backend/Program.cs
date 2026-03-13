using Articulos_Backend;
using Articulos_Backend.Articulos;
using Articulos_Backend.Endpoints;
using Articulos_Backend.Middleware;
using Articulos_Backend.Repositorios;
using ClientesASPNET;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var repositorioCliente = new ClienteRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
var repositorioArticulo = new ArticuloRepository(builder.Configuration.GetConnectionString("DefaultConnection"));
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
app.Run();