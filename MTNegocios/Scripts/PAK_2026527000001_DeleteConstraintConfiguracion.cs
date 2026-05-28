using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000001_DeleteConstraintConfiguracion:Script
    {
        public PAK_2026527000001_DeleteConstraintConfiguracion(){
            this.script= "ALTER TABLE Configuraciones DROP CONSTRAINT FK_Configuraciones_Usuarios";
        }
    }
}
