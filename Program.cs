using System.Linq;
using Articulos_Backend;
using Articulos_Backend.Endpoints;

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

// Register Articulo endpoints from a separate file
app.MapArticuloEndpoints();

app.Run();
