using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000003_NuevoCampoIdUsuarios:Script
    {
        public PAK_2026527000003_NuevoCampoIdUsuarios()
        {
            this.script = "ALTER TABLE Usuarios ADD Id NVARCHAR(36) NOT NULL";
        }
    }
}
