using Articulos_Backend.Repositorios.Ventas;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints.Ventas;

public static class PedidoEndpoints
{
    public static WebApplication MapPedidoEndpoints(this WebApplication app, PedidoRepository repo)
    {
        app.MapGet("/pedidos", () => {
            return repo.ObtenerPedidos();
        }).Produces<List<Pedido>>(StatusCodes.Status200OK);
        app.MapGet("/pedidos/{id}", (int id) =>
        {
            var pedido = repo.ObtenerPorId(id);
            return pedido is not null
                ? Results.Ok(pedido)
                : Results.NotFound();
        })
            .Produces<Pedido>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        app.MapGet("/pedidos/cliente", (string? dni) => {
            var pedidos = string.IsNullOrEmpty(dni)
                ? repo.ObtenerPedidos()
                : repo.ObtenerPorDniCliente(dni);
            return Results.Ok(pedidos);
        }).Produces<List<Pedido>>(StatusCodes.Status200OK);
        app.MapGet("/pedidos/estado", (string estado) => {
            var pedidos = repo.ObtenerPorEstado(estado);
            return Results.Ok(pedidos);
        }).Produces<List<Cliente>>(StatusCodes.Status200OK);
        app.MapPost("/pedidos", (Pedido pedido) =>
        {
            var existente = repo.ObtenerPorId(pedido.id_pedido);
            if (existente != null)
            {
                return Results.Conflict($"Ya existe un pedido con id: {pedido.id_pedido}");
            }
            repo.Insertar(pedido);
            return Results.Created($"/pedidos/{pedido.id_pedido}", pedido);
        })
        .Produces<Cliente>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/pedidos/{id}", (int id, Pedido pedidoActualizado) =>
        {
            var cliente = repo.ObtenerPorId(id);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            pedidoActualizado.id_pedido = id;
            repo.Actualizar(pedidoActualizado);
            return Results.Ok(pedidoActualizado);
        })
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapDelete("/pedidos/{id}", (int id) =>
        {
            var pedido = repo.ObtenerPorId(id);
            if (pedido == null)
            {
                return Results.NotFound();
            }
            repo.Eliminar(id);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
        return app;
    }
}
