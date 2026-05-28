using MTCore_AC.DTO;


namespace MTNegocios.Scripts;

public class PAK_2026526000001_CreateAuditoria: Script
{
    public PAK_2026526000001_CreateAuditoria()
    {
        this.script = """
            IF OBJECT_ID('Auditoria', 'U') IS NULL
        BEGIN
            CREATE TABLE Auditoria
            (
                Id UNIQUEIDENTIFIER PRIMARY KEY,
                Usuario NVARCHAR(200) NOT NULL,
                Accion NVARCHAR(50) NOT NULL,
                Entidad NVARCHAR(100) NOT NULL,
                EntidadId NVARCHAR(100) NULL,
                Fecha DATETIME2 NOT NULL,
                Datos NVARCHAR(MAX) NULL
            )
        END
        """;
    }
}
