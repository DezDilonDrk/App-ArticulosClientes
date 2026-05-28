using MTCore_AC.DTO;
using System.Runtime.CompilerServices;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000004_ConstraintDefaultUsuario: Script
    {
        public PAK_2026527000004_ConstraintDefaultUsuario() {
            this.script = "ALTER TABLE Usuarios ADD CONSTRAINT DF_Usuarios_Id DEFAULT NEWID() FOR Id";
        }
    }
}
