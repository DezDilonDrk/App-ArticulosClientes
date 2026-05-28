using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000000_CreateConfiguracion: Script
{
    public PAK_2026429000000_CreateConfiguracion()
    {
        this.script = """
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Configuraciones')
BEGIN
CREATE TABLE Configuraciones(
id_configuracion NVARCHAR(36) NOT NULL,
correo_usuario NVARCHAR(255) NOT NULL,
config_json VARBINARY(max) NULL,
CONSTRAINT PK_Configuracion PRIMARY KEY CLUSTERED (id_configuracion))
END
""";
    }
}
