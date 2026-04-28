IF NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'ADMIN_SEGURIDAD')
BEGIN
    INSERT INTO Roles (Nombre, Descripcion)
    VALUES ('ADMIN_SEGURIDAD', 'Permisos para gestionar roles y usuarios');
END

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'ADMIN_ALMACEN')
BEGIN
    INSERT INTO Roles (Nombre, Descripcion)
    VALUES ('ADMIN_ALMACEN', 'Permisos para gestionar articulos');
END

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'ADMIN_VENTAS')
BEGIN
    INSERT INTO Roles (Nombre, Descripcion)
    VALUES ('ADMIN_VENTAS', 'Permisos para gestionar clientes, pedidos y envios');
END

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'USER_ALMACEN')
BEGIN
    INSERT INTO Roles (Nombre, Descripcion)
    VALUES ('USER_ALMACEN', 'Permisos para visualizar articulos');
END

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Nombre = 'USER_VENTAS')
BEGIN
    INSERT INTO Roles (Nombre, Descripcion)
    VALUES ('USER_VENTAS', 'Permisos para visualizar clientes, pedidos y envios');
END