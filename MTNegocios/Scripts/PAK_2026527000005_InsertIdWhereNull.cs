using MTCore_AC.DTO;

namespace MTNegocios.Scripts
{
    public class PAK_2026527000005_InsertIdWhereNull: Script
    {
        public PAK_2026527000005_InsertIdWhereNull() {
            this.script = "UPDATE Usuarios SET Id = NEWID() WHERE Id IS NULL";
        }
    }
}
