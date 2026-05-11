using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Seguridad;

namespace MTNegocios.MTEndpoints.Seguridad;

public class UsuarioMethods
{
    private readonly UsuarioRepository _repo;

    public UsuarioMethods(UsuarioRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Usuario>> ObtenerUsuarios()
    {
        var usuarios = await _repo.ObtenerUsuarios();
        return usuarios.ToList();
    }

    public async Task<Usuario?> ObtenerPorCorreo(string correoElectronico)
    {
        var usuario = await _repo.ObtenerPorCorreo(correoElectronico);
        return usuario;
    }

    public async Task<Usuario?> ObtenerPorNombre(string nombre)
    {
        var usuario = await _repo.ObtenerPorNombre(nombre);
        return usuario;
    }

    public async Task<List<string>> ObtenerRolesPorUsuario(string correoElectronico)
    {
        var roles = await _repo.ObtenerRolesPorUsuario(correoElectronico);
        return roles;
    }

    public async Task Insertar(Usuario usuario)
    {
        await _repo.Insertar(usuario);
    }

    public async Task Actualizar(Usuario usuario)
    {
        await _repo.Update(usuario);
    }

    public async Task ActualizarContrasena(string correoElectronico, string nuevaContrasena)
    {
        await _repo.ActualizarContrasena(correoElectronico, nuevaContrasena);
    }

    public async Task ActualizarRoles(string correoElectronico, List<string> roles)
    {
        await _repo.ActualizarRoles(correoElectronico, roles);
    }

    public async Task Eliminar(string correoElectronico)
    {
        await _repo.Eliminar(correoElectronico);
    }
}
