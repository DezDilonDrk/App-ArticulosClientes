using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000002_ConstraintsPedidoArticulos: Script
{
    public PAK_2026429000002_ConstraintsPedidoArticulos()
    {
        this.script = """
ALTER TABLE Pedido_Articulos
ADD CONSTRAINT FK_IdArticulo FOREIGN KEY(id_articulo) REFERENCES Articulos(Id),
CONSTRAINT FK_IdPedido FOREIGN KEY (id_pedido) REFERENCES Pedidos(id_pedido);
""";
    }
}
