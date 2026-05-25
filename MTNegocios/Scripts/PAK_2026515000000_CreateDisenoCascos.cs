using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026515000000_CreateDisenoCascos: Script
{
    public PAK_2026515000000_CreateDisenoCascos()
    {
        this.script = """
CREATE TABLE DisenoCascos(
    Id NVARCHAR(36) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    CONSTRAINT PK_DisenoCascos PRIMARY KEY CLUSTERED (Id)
);
""";
    }
}
