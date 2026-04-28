IF OBJECT_ID('Pedidos', 'P') IS NULL
BEGIN
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
	fecha_envio DATETIME2(7) NOT NULL);
END