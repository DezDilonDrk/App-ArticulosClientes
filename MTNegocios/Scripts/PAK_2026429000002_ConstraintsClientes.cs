using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000002_ConstraintsClientes: Script
{
    public PAK_2026429000002_ConstraintsClientes()
    {
        this.script = """
IF NOT EXISTS (SELECT * FROM sys.default_constraints WHERE name = 'DF__Clientes__FechaC__5CD6CB2B')
BEGIN
ALTER TABLE Clientes
ADD CONSTRAINT DF__Clientes__FechaC__5CD6CB2B DEFAULT (getdate()) FOR FechaCreacion
END
""";
    }
}