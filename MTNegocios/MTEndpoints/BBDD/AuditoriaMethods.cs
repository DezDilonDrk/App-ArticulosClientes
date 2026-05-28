using System.Text.Json;
using MTCore_AC.Entidades;
using MTNegocios.Repositorios;

namespace MTNegocios.MTEndpoints.BBDD;

public class AuditoriaMethods
{
    private readonly AuditoriaRepository _repo;

    public AuditoriaMethods(AuditoriaRepository repo)
    {
        _repo = repo;
    }

    public async Task Registrar(
        string usuario,
        string accion,
        string entidad,
        string? entidadId = null,
        object? datos = null)
    {
        var auditoria = new Auditoria
        {
            Id = Guid.NewGuid().ToString(),
            Usuario = usuario,
            Accion = accion,
            Entidad = entidad,
            EntidadId = entidadId,
            Fecha = DateTime.Now,
            Datos = datos != null
                ? JsonSerializer.Serialize(datos)
                : null
        };

        await _repo.Insertar(auditoria);

    }
}
