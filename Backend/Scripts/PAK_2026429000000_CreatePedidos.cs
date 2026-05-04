using MTCore_AC.DTO;

namespace Articulos_Backend.Scripts;

public class PAK_2026429000000_CreatePedidos: Script
{
    public PAK_2026429000000_CreatePedidos()
    {
        this.script = """
CREATE TABLE Pedidos(
id_pedido NVARCHAR(36) NOT NULL,
id_cliente NVARCHAR(36) NOT NULL,
dni_cliente NVARCHAR(20) NOT NULL,
nombre_cliente NVARCHAR(100) NOT NULL,
metodo_pago NVARCHAR(50) NOT NULL,
fecha_creacion DATETIME2(7) NOT NULL,
fecha_rectificacion DATETIME2(7) NULL,
estado NVARCHAR(100) NOT NULL,
porcentaje_impuestos INT NOT NULL,
fecha_envio DATETIME2(7) NOT NULL,
CONSTRAINT PK_Pedidos PRIMARY KEY CLUSTERED (id_pedido)
);
""";
    }
}
