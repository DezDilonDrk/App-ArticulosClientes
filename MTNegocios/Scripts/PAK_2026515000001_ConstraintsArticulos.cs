using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026515000001_ConstraintsArticulos: Script
{
    public PAK_2026515000001_ConstraintsArticulos()
    {
        this.script = """
            IF NOT EXISTS (
                SELECT * 
                FROM sys.foreign_keys 
                WHERE name = 'FK_Articulos_DisenoCascos'
            )
            BEGIN
                ALTER TABLE Articulos
                ADD CONSTRAINT FK_Articulos_DisenoCascos
                FOREIGN KEY (IdDisenoCasco)
                REFERENCES DisenoCascos(Id)
                ON DELETE SET NULL
            END

            IF NOT EXISTS (
                SELECT * 
                FROM sys.objects
                WHERE name = 'UQ_Articulos_Nombre'
            )
            BEGIN
                ALTER TABLE Articulos
                ADD CONSTRAINT UQ_Articulos_Nombre
                UNIQUE (Nombre)
            END
            """;
    }
}
