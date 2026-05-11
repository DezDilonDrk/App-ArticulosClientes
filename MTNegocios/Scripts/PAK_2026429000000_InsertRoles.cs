using MTCore_AC.DTO;

namespace MTNegocios.Scripts;

public class PAK_2026429000000_InsertRoles: Script
{
    public PAK_2026429000000_InsertRoles()
    {
        this.script = """
INSERT INTO Roles (Nombre, Descripcion)
VALUES
('ADMIN_SEGURIDAD', 'Permisos para gestionar roles y usuarios'),
('ADMIN_ALMACEN', 'Permisos para gestionar articulos'),
('ADMIN_VENTAS', 'Permisos para gestionar clientes, pedidos y envios'),
('USER_ALMACEN', 'Permisos para visualizar articulos'),
('USER_VENTAS', 'Permisos para visualizar clientes, pedidos y envios');
""";
    }
}
