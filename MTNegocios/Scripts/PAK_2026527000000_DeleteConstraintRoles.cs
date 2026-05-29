using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000001_DeleteConstraintRoles: Script
    {
        public PAK_2026527000001_DeleteConstraintRoles()
        {
            this.script = "ALTER TABLE UsuarioRoles DROP CONSTRAINT FK_UsuarioRoles_Usuarios";
        }
    }
}
