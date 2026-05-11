using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Seguridad;

namespace MTNegocios.MTEndpoints.Seguridad;

public class ConfiguracionMethods
{
    private readonly ConfiguracionRepository _repo;

    public ConfiguracionMethods(ConfiguracionRepository repo)
    {
        _repo = repo;
    }

    public async Task<ConfiguracionModel?> ObtenerConfiguracionPorCorreo(string correo)
    {
        return await _repo.ObtenerConfiguracionPorCorreo(correo);
    }

    public async Task GuardarConfiguracionPorCorreo(string id, ConfiguracionModel configuracion, string correo)
    {
        await _repo.GuardarConfiguracionPorCorreo(id, configuracion, correo);
    }

}