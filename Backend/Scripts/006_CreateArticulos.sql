IF OBJECT_ID('Articulos', 'A') IS NULL
BEGIN
    CREATE TABLE Articulos(
	Id INT IDENTITY(1,1) NOT NULL,
	Nombre NVARCHAR(200) NOT NULL,
	Precio FLOAT NOT NULL,
	Categoria [nvarchar](100) NULL,
	FechaCreacion DATETIME2(7) NOT NULL,
	FechaActualizacion DATETIME2(7) NULL);
END