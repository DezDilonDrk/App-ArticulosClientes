using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000002_ConstraintsPedidos: Script
{
    public PAK_2026429000002_ConstraintsPedidos()
    {
        this.script = """
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Pedidos_Clientes')
BEGIN
ALTER TABLE Pedidos
ADD CONSTRAINT DF__Pedidos__id__clie__208CD6FA DEFAULT ('id inexistente') FOR id_cliente,
CONSTRAINT DG__Pedidos__Nombre__2645B050 DEFAULT ('No User') FOR nombre_cliente,
CONSTRAINT FK_Pedidos_Clientes FOREIGN KEY(id_cliente) REFERENCES Clientes(Id)
END
""";
    }
}
