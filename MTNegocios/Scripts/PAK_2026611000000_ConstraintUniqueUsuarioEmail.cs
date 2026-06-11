using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026611000000_ConstraintUniqueUsuarioEmail: Script
    {
        public PAK_2026611000000_ConstraintUniqueUsuarioEmail()
        {
            this.script = "ADD CONSTRAINT UQ_Usuarios_CorreoElectronico UNIQUE (CorreoElectronico)"; //A lo mejor esto falla, es para hacer pruebas
        }
    }
}
