using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Seguridad;

namespace MTNegocios.MTEndpoints.Seguridad;

public class UsuarioRolMethods
{
    private readonly UsuarioRolRepository _repo;
    public UsuarioRolMethods(UsuarioRolRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<UsuarioRol>> ObtenerAll()
    {
        var roles = await _repo.ObtenerAll();
        return roles;
    }
    
    public async Task<UsuarioRol?> ObtenerPorRolYUsuario(int rolId, string usuarioEmail)
    {
        var rol = await _repo.ObtenerPorRolYUsuario(rolId, usuarioEmail);
        return rol;
    }

    public async Task<IEnumerable<UsuarioRol>> ObtenerPorRol(int rolId)
    {
        var roles = await _repo.ObtenerPorRol(rolId);
        return roles;
    }

    public async Task<IEnumerable<UsuarioRol>> ObtenerPorUsuario(string usuarioEmail)
    {
        var roles = await _repo.ObtenerPorUsuario(usuarioEmail);
        return roles;
    }

    public async Task<IEnumerable<Rol>> ObtenerRolesPorUsuario(string usuarioEmail)
    {
        var roles = await _repo.ObtenerRolesPorUsuario(usuarioEmail);
        return roles;
    }

    public async Task Eliminar(int rolId, string usuarioEmail)
    {
        var existing = await _repo.ObtenerPorRolYUsuario(rolId, usuarioEmail) ?? throw new KeyNotFoundException("Asignación no encontrada");
        await _repo.Eliminar(rolId, usuarioEmail);
    }
}
