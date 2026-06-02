using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026602000000_ConstraintUniqueUsuarioCorreo: Script
    {
        public PAK_2026602000000_ConstraintUniqueUsuarioCorreo()
        {
            this.script = "ALTER TABLE PracticasDB.dbo.Usuarios ADD CONSTRAINT UQ_Usuarios_CorreoElectronico UNIQUE (CorreoElectronico)";
        }
    }
}
