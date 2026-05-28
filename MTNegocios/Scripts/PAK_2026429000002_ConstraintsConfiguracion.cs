using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000002_ConstraintsConfiguracion: Script
{
    public PAK_2026429000002_ConstraintsConfiguracion()
    {
        this.script = """
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Configuraciones_Usuarios')
BEGIN
ALTER TABLE Configuraciones
ADD CONSTRAINT FK_Configuraciones_Usuarios FOREIGN KEY(correo_usuario) REFERENCES Usuarios(CorreoElectronico)
END
""";
    }
}
