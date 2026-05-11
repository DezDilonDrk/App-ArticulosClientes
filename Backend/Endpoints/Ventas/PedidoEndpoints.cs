using Articulos_Backend.JWT;
using MTCore_AC.Entidades;
using MTNegocios.MTEndpoints.Ventas;

namespace Articulos_Backend.Endpoints.Ventas;

public static class PedidoEndpoints
{
    public static WebApplication MapPedidoEndpoints(this WebApplication app)
    {
        app.MapGet("/pedidos", async (string? nombre, PedidoMethods methods) => {
            var productos = string.IsNullOrEmpty(nombre)
                ? await methods.ObtenerPedidos()
                : await methods.BuscarPorNombreCliente(nombre);
            return Results.Ok(productos);
        });//.RequireAuthorization(policy => policy.RequireRole(Roles.AdminPedidos, Roles.UserPedidos)).Produces<List<Pedido>>(StatusCodes.Status200OK);
        app.MapGet("/pedidos/cliente", async (string? dni, PedidoMethods methods) => {
            var pedidos = string.IsNullOrEmpty(dni)
                ? await methods.ObtenerPedidos()
                : await methods.ObtenerPorDniCliente(dni);
            return Results.Ok(pedidos);
        }).Produces<List<Pedido>>(StatusCodes.Status200OK);
        app.MapGet("/pedidos/estado", async (string estado, PedidoMethods methods) => {
            var pedidos = await methods.ObtenerPorEstado(estado);
            return Results.Ok(pedidos);
        }).Produces<List<Pedido>>(StatusCodes.Status200OK);
        app.MapGet("/pedidos/{id}", async (string id, PedidoMethods methods) => {
            var pedidos = await methods.ObtenerPorId(id);
            return Results.Ok(pedidos);
        }).Produces<List<Pedido>>(StatusCodes.Status200OK);
        app.MapPost("/pedidos", async (Pedido pedido, PedidoMethods methods) =>
        {
            await methods.Insertar(pedido);
           foreach(PedidoArticulos a in pedido.articulos) { 
               a.id_pedido = pedido.id_pedido;
               await methods.AgregarArticulo(a);
            }
            return Results.Created($"/pedidos/{pedido.id_pedido}", pedido);
        })
        .Produces<Pedido>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/pedidos/{id}", async (string id, Pedido pedidoActualizado, PedidoMethods methods) =>
        {
            pedidoActualizado.id_pedido = id;
            await methods.Actualizar(pedidoActualizado);
            return Results.Ok(pedidoActualizado);
        })
        .Produces<Pedido>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapPut("/pedidos/articulo{id}", async (string id, PedidoArticulos articulo, PedidoMethods methods) =>
        {
            var cliente = await methods.ObtenerPorId(id);
            if (cliente == null)
            {
                return Results.NotFound();
            }
            articulo.id_pedido = id;
            await methods.AgregarArticulo(articulo);
            return Results.Ok(articulo);
        })
        .Produces<PedidoArticulos>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status409Conflict);
        app.MapGet("/pedidos/{idPedido}/articulos", async (string idPedido, PedidoMethods methods) =>
        {
            var articulosPedidos = await methods.ObtenerArticulosPorPedido(idPedido);
            return articulosPedidos is not null ? Results.Ok(articulosPedidos) : Results.NotFound();
        })
        .Produces<List<PedidoArticulos>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
        app.MapDelete("/pedidos/{id}", async (string id, PedidoMethods methods) =>
        {
            var pedido = await methods.ObtenerPorId(id);
            if (pedido == null)
            {
                return Results.NotFound();
            }
            await methods.Eliminar(id);
            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
        return app;
    }
}
