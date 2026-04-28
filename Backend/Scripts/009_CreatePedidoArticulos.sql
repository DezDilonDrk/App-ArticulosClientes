IF OBJECT_ID('PedidosArticulos', 'PA') IS NULL
BEGIN
    CREATE TABLE Pedido_Articulos(
	id INT IDENTITY(1,1) NOT NULL,
	id_pedido NVARCHAR(36) NOT NULL,
	id_articulo INT NOT NULL,
	cantidad INT NOT NULL,
	precio_unidad FLOAT NOT NULL);
END