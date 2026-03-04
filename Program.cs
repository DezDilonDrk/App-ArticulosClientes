using Articulos_Backend;
using Articulos_Backend.Articulos;
using Articulos_Backend.Endpoints;
using ClientesASPNET;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapClienteEndpoints();
app.MapArticuloEndpoints();
app.Run();
