using MTCore_AC.DTO;

namespace Articulos_Backend.Scripts;

public class PAK_2026429000000_CreateConfiguracion: Script
{
    public PAK_2026429000000_CreateConfiguracion()
    {
        this.script = """
CREATE TABLE Configuraciones(
id_configuracion NVARCHAR(36) NOT NULL,
correo_usuario VARCHAR(255) NOT NULL,
config_json VARBINARY(max) NULL);
""";
    }
}
