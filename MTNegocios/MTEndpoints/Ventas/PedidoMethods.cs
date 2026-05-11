using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Ventas;

namespace MTNegocios.MTEndpoints.Ventas;

public class PedidoMethods
{
    private readonly PedidoRepository _repo;
    public PedidoMethods(PedidoRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Pedido>> ObtenerPedidos()
    {
        var pedidos = await _repo.ObtenerPedidos();
        return pedidos;
    }
    public async Task<Pedido> ObtenerPorId(string id)
    {
        var pedido = await _repo.ObtenerPorId(id);
        return pedido;
    }
    public async Task<List<Pedido>> BuscarPorNombreCliente(string Nombre)
    {
        var pedidos = await _repo.BuscarPorNombreCliente(Nombre);
        return pedidos;
    }
    public async Task<List<Pedido>> ObtenerPorDniCliente(string dni)
    {
        var pedidos = await _repo.ObtenerPorDniCliente(dni);
        return pedidos;
    }
    public async Task<List<PedidoArticulos>> ObtenerArticulosPorPedido(string id_pedido)
    {
        var articulos = await _repo.ObtenerArticulosPorPedido(id_pedido);
        return articulos;
    }

    public async Task<Pedido> ObtenerPorIdArticulo(string id)
    {
        var pedido = await _repo.ObtenerPorIdArticulo(id);
        return pedido;
    }
    
    public async Task<List<Pedido>> ObtenerPorEstado(string estado)
    {
        var pedidos = await _repo.ObtenerPorEstado(estado);
        return pedidos;
    }

    public async Task Insertar(Pedido pedido)
    {
        await _repo.Insertar(pedido);
    }

    public async Task AgregarArticulo(PedidoArticulos articulo)
    {
        await _repo.AgregarArticulo(articulo);
    }

    

    public async Task Actualizar(Pedido pedido)
    {
        await _repo.Actualizar(pedido);
    }

    public async Task Eliminar(string id)
    {
        await _repo.Eliminar(id);
    }
}
