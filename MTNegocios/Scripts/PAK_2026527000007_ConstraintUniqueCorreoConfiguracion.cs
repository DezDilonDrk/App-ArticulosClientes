using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000007_ConstraintUniqueCorreoConfiguracion: Script
    {
        public PAK_2026527000007_ConstraintUniqueCorreoConfiguracion()
        {
            this.script = "ALTER TABLE Configuraciones ADD CONSTRAINT UQ_Configuraciones_CorreoElectronico UNIQUE (correo_usuario)";
        }
    }
}
