using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Almacen;

namespace MTNegocios.MTEndpoints.Almacen;

public class ArticuloMethods
{
    private readonly ArticuloRepository _repo;
    public ArticuloMethods(ArticuloRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<Articulo>> ObtenerArticulos()
    {
        var articulos = await _repo.ObtenerArticulos();
        return articulos;
    }
    public async Task<Articulo?> ObtenerPorId(string id)
    {
        var articulo = await _repo.ObtenerPorId(id);
        return articulo;
    }
    public async Task<IEnumerable<Articulo>> ObtenerPorNombre(string nombre)
    {
        var articulos = await _repo.ObtenerPorNombre(nombre);
        return articulos;
    }
    public async Task<Articulo?> ObtenerPorNombreExacto(string nombre)
    {
        var articulo = await _repo.ObtenerPorNombreExacto(nombre);
        return articulo;
    }
    public async Task<string> Insertar(Articulo articulo)
    {
        var id = await _repo.Insertar(articulo);
        return id;
    }

    public async Task Actualizar(Articulo articulo)
    {
        await _repo.Actualizar(articulo);
    }

    public async Task Eliminar(string id)
    {
        await _repo.Eliminar(id);
    }
}
