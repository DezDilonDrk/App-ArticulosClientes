using MTCore_AC.DTO;
using System.Runtime.CompilerServices;

namespace Articulos_Backend.Scripts;

public class PAK_2026429000000_CreateClientes: Script
{
    public PAK_2026429000000_CreateClientes()
    {
        this.script = """
CREATE TABLE Clientes(
Id NVARCHAR(36) NOT NULL,
Dni NVARCHAR(20) NOT NULL,
Nombre NVARCHAR(100) NOT NULL,
Apellidos NVARCHAR(150) NOT NULL,
Email NVARCHAR(150) NOT NULL,
FechaCreacion DATETIME2(7) NOT NULL,
FechaModificacion DATETIME2(7) NULL);
""";
    }
}
