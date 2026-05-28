using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000006_ConstraintUniqueUsuarioId: Script
    {
        public PAK_2026527000006_ConstraintUniqueUsuarioId()
        {
            this.script = "ALTER TABLE PracticasDB.dbo.Usuarios ADD CONSTRAINT UQ_Usuarios_Id UNIQUE (Id)";
        }
    }
}
