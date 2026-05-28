using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000002_DeleteConstraintUsuarios: Script
    {
        public PAK_2026527000002_DeleteConstraintUsuarios()
        {
            this.script = "ALTER TABLE Usuarios DROP CONSTRAINT PK_Usuarios";
        }
    }
}
