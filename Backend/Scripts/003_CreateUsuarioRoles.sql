IF OBJECT_ID('UsuarioRoles', 'UR') IS NULL
BEGIN
    CREATE TABLE UsuarioRoles(
        UsuarioEmail NVARCHAR(255) NOT NULL,
        RolId INT NOT NULL,

        CONSTRAINT PK_UsuarioRoles PRIMARY KEY (UsuarioEmail, RolId),

        CONSTRAINT FK_UsuarioRoles_Usuarios 
            FOREIGN KEY (UsuarioEmail) 
            REFERENCES Usuarios(CorreoElectronico)
            ON DELETE CASCADE,

        CONSTRAINT FK_UsuarioRoles_Roles 
            FOREIGN KEY (RolId) 
            REFERENCES Roles(Id)
            ON DELETE CASCADE
    );
END