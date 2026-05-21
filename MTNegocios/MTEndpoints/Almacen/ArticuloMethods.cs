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

    public async Task<IEnumerable<ArticuloDTO>> ObtenerArticuloDTO()
    {
        var articulos = await _repo.ObtenerArticuloDTO();
        return articulos;
    }

    public async Task<IEnumerable<DisenoCasco>> ObtenerDisenosCascos()
    {
        var disenos = await _repo.ObtenerDisenosCascos();
        return disenos;
    }

    public  async Task<DisenoCasco> ObtenerDisenoPorId(string id)
    {
        var diseno = await _repo.ObtenerDisenoPorId(id);
        return diseno;
    }

    public async Task<string> ObtenerIdDiseno(string nombre)
    {
        var id = await _repo.ObtenerIdDiseno(nombre);
        return id;
    }

    public async Task<string> Insertar(Articulo articulo)
    {
        var id = await _repo.Insertar(articulo);
        return id;
    }

    public async Task<string> InsertarDiseno(DisenoCasco diseno)
    {
        var id = await _repo.InsertarDiseno(diseno);
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
