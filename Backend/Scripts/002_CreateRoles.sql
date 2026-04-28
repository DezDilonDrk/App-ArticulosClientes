IF OBJECT_ID('Roles', 'U') IS NULL
BEGIN
    CREATE TABLE Roles(
        Id INT IDENTITY PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Descripcion NVARCHAR(255),

        CONSTRAINT UQ_Roles_Nombre UNIQUE (Nombre)
    );
END