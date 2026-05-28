using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000000_CreateRoles: Script
{
    public PAK_2026429000000_CreateRoles()
    {
        this.script = """
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Roles')
BEGIN
CREATE TABLE Roles(
Id INT IDENTITY PRIMARY KEY,
Nombre NVARCHAR(100) NOT NULL,
Descripcion NVARCHAR(255),
CONSTRAINT UQ_Roles_Nombre UNIQUE (Nombre)
)
END
""";
    }
}
