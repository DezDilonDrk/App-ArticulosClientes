using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000000_CreateUsuarios: Script
{
    public PAK_2026429000000_CreateUsuarios()
    {
        this.script = """
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Usuarios')
BEGIN
CREATE TABLE Usuarios(
CorreoElectronico NVARCHAR(255) NOT NULL,
NombreUsuario NVARCHAR(100) NOT NULL,
Contrasena NVARCHAR(255) NOT NULL,
CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED (CorreoElectronico)
)
END
""";
    }
}
