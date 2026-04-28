IF OBJECT_ID('Usuarios', 'U') IS NULL
BEGIN
    CREATE TABLE Usuarios(
        CorreoElectronico NVARCHAR(255) NOT NULL PRIMARY KEY,
        NombreUsuario NVARCHAR(100) NOT NULL,
        Contrasena NVARCHAR(255) NOT NULL
    );
END



