using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026515000001_ConstraintsArticulos: Script
{
    public PAK_2026515000001_ConstraintsArticulos()
    {
        this.script = """
            ALTER TABLE Articulos
            ADD CONSTRAINT FK_Articulos_DisenoCascos FOREIGN KEY (IdDisenoCasco) REFERENCES DisenoCascos(Id) ON DELETE SET NULL;
                CONSTRAINT UQ_Articulos_250520266092C80 UNIQUE (Nombre);
            """;
    }
}
