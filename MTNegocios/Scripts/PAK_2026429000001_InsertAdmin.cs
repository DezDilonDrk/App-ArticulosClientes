using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000001_InsertAdmin: Script
{
    public PAK_2026429000001_InsertAdmin()
    {
        this.script = """
INSERT INTO Usuarios (CorreoElectronico, NombreUsuario, Contrasena)
VALUES (
'admin@mthelmets.com',
'Administrador',
'$2a$11$8esi3nzFR5YRGsNkOxwy4.CqN7eSn3ICMDrHbTaUwi.2yI8IDt6Ci'
)
INSERT INTO UsuarioRoles (UsuarioEmail, RolId)
SELECT 'admin@mthelmets.com', Id
FROM Roles
WHERE Nombre IN ('ADMIN_SEGURIDAD', 'ADMIN_ALMACEN', 'ADMIN_VENTAS')
""";
    }
}
