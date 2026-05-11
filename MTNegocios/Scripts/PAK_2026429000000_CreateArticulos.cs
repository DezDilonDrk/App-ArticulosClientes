using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000000_CreateArticulos: Script
{
    public PAK_2026429000000_CreateArticulos()
    {
        this.script = """
CREATE TABLE Articulos(
Id NVARCHAR(36) NOT NULL,
Nombre NVARCHAR(200) NOT NULL,
Precio FLOAT NOT NULL,
Categoria NVARCHAR(100) NULL,
FechaCreacion DATETIME2(7) NOT NULL,
FechaActualizacion DATETIME2(7) NULL,
CONSTRAINT PK_Articulos PRIMARY KEY CLUSTERED (Id)
);
""";
    }
}
