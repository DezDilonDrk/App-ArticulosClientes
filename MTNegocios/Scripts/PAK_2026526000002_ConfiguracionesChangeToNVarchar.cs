using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026526000002_ConfiguracionesChangeToNVarchar: Script
    {
        public PAK_2026526000002_ConfiguracionesChangeToNVarchar()
        {
            this.script = "ALTER TABLE Configuraciones ALTER COLUMN config_json NVARCHAR(MAX) NULL";
        }
    }
}
