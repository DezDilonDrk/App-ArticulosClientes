using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Ventas;

namespace MTNegocios.MTEndpoints.Ventas;

public class ClienteMethods
{
    private readonly ClienteRepository _repo;

    public ClienteMethods(ClienteRepository repo)
    {
        _repo = repo;
    }

    public async Task<Cliente?> ObtenerPorDni(string dni)
    {
        var cliente = await _repo.ObtenerPorDni(dni);
        return cliente;
    }

    public async Task<List<Cliente>> BuscarPorNombre(string nombre)
    {
        var clientes = await _repo.BuscarPorNombre(nombre);
        return clientes;
    }

    public async Task<List<Cliente>> ObtenerClientes()
    {
        var clientes = _repo.ObtenerClientes();
        return clientes;
    }
    public async Task Insertar(Cliente cliente)
    {
        await _repo.Insertar(cliente);
    }

    public async Task Actualizar(Cliente cliente)
    {
            await _repo.Actualizar(cliente);
    }

    public async Task Eliminar(string dni)
    {
        await _repo.Eliminar(dni);
    }
}
