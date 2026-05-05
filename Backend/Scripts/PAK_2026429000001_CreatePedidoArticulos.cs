using MTCore_AC.DTO;

namespace Articulos_Backend.Scripts;

public class PAK_2026429000001_CreatePedidoArticulos: Script
{
    public PAK_2026429000001_CreatePedidoArticulos()
    {
        this.script = """
CREATE TABLE Pedido_Articulos(
id INT IDENTITY(1,1) NOT NULL,
id_pedido NVARCHAR(36) NOT NULL,
id_articulo NVARCHAR(36) NOT NULL,
cantidad INT NOT NULL,
precio_unidad FLOAT NOT NULL,
CONSTRAINT PK_PedidoArticulos PRIMARY KEY CLUSTERED (id));
""";
    }
}
