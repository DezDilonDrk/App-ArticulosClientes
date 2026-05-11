using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Seguridad;

namespace MTNegocios.MTEndpoints.Seguridad;

public class RolMethods
{
    private readonly RolRepository _repo;
    public RolMethods(RolRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Rol>> ObtenerRoles()
    {
        var roles = await _repo.ObtenerRoles();
        return roles;
    }

    public async Task<IEnumerable<Rol>> ObtenerNombreRoles()
    {
        var nombres = await _repo.ObtenerNombreRoles();
        return nombres;
    }

    public async Task<Rol> ObtenerPorId(int id)
    {
        var rol = await _repo.ObtenerPorId(id);
        return rol;
    }

    public async Task<Rol> ObtenerPorNombre(string nombre)
    {
        var rol = await _repo.ObtenerPorNombre(nombre);
        return rol;
    }

    public async Task<int> Insertar(Rol rol)
    {
        var existente = await _repo.ObtenerPorNombre(rol.Nombre);
        if (existente != null) { throw new InvalidOperationException($"Ya existe un rol con nombre '{rol.Nombre}'"); }
        int id = await _repo.Insertar(rol);
        rol.Id = id;
        return id;
    }

    public async Task<Rol> Actualizar(int id, Rol updatedRol)
    {
        var existing = await _repo.ObtenerPorId(id) ?? throw new KeyNotFoundException("Rol no encontrado");
        updatedRol.Id = id;
        await _repo.Actualizar(updatedRol);
        var refreshed = await _repo.ObtenerPorId(id) ?? updatedRol;
        return refreshed;
    }

    public async Task Eliminar(int id)
    {
        var existing = await _repo.ObtenerPorId(id) ?? throw new KeyNotFoundException("Rol no encontrado");
        await _repo.Eliminar(id);
    }
}
