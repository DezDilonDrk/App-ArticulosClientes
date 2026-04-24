using Articulos_Backend.JWT;
using Articulos_Backend.Repositorios.Ventas;
using MTCore_AC.Entidades;

namespace Articulos_Backend.Endpoints.Ventas;

public static class PedidoEndpoints
{
    public static WebApplication MapPedidoEndpoints(this WebApplication app, PedidoRepository repo)
    {
        app.MapGet("/pedidos", (string? nombre) => {
            var productos = string.IsNullOrEmpty(nombre)
                ? repo.ObtenerPedidos()
                : repo.BuscarPorNombreCliente(nombre);
            return Results.Ok(productos);
        });//.RequireAuthorization(policy => policy.RequireRole(Roles.AdminPedidos, Roles.UserPedidos)).Produces<List<Pedido>>(StatusCodes.Status200OK);
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
        app.MapGet("/pedidos/{id}", (string id) => {
            var pedidos = repo.ObtenerPorId(id);
            return Results.Ok(pedidos);
        }).Produces<List<Cliente>>(StatusCodes.Status200OK);
        app.MapPost("/pedidos", (Pedido pedido) =>
        {
            repo.Insertar(pedido);
           foreach(PedidoArticulos a in pedido.articulos) { 
               a.id_pedido = pedido.id_pedido;
               repo.AgregarArticulo(a);
            }
            return Results.Created($"/pedidos/{pedido.id_pedido}", pedido);
        })
        .Produces<Cliente>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/pedidos/{id}", (string id, Pedido pedidoActualizado) =>
        {
            pedidoActualizado.id_pedido = id;
            repo.Actualizar(pedidoActualizado);
            return Results.Ok(pedidoActualizado);
        })
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/pedidos/articulo{id}", (string id, PedidoArticulos articulo) =>
        {
            var cliente = repo.ObtenerPorId(id);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            articulo.id_pedido = id;
            repo.AgregarArticulo(articulo);
            return Results.Ok(articulo);
        })
        .Produces<Cliente>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapGet("/pedidos/{idPedido}/articulos", (string idPedido) =>
        {
            List<PedidoArticulos> articulosPedidos = repo.ObtenerArticulosPorPedido(idPedido);
            return articulosPedidos is not null ? Results.Ok(articulosPedidos) : Results.NotFound();
        })
        .Produces<Usuario>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        app.MapDelete("/pedidos/{id}", (string id) =>
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
