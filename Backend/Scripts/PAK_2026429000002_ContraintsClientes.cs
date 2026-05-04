using MTCore_AC.DTO;

namespace Articulos_Backend.Scripts;

public class PAK_2026429000002_ContraintsClientes: Script
{
    public PAK_2026429000002_ContraintsClientes()
    {
        this.script = """
ALTER TABLE Clientes
ADD CONSTRAINT DF__Clientes__FechaC__5CD6CB2B DEFAULT (getdate()) FOR FechaCreacion;
""";
    }
}