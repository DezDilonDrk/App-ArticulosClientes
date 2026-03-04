using Articulos_Backend.Articulos;
using Articulos_Backend.Endpoints;
using ClientesASPNET;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// OpenAPI is preserved
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapClienteEndpoints();

app.MapArticuloEndpoints();



app.Run();
