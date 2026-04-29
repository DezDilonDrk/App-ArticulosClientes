using MTCore_AC.DTO;

namespace Articulos_Backend.Scripts;

public class PAK_2026429000001_CreateUsuarioRoles: Script
{
    public PAK_2026429000001_CreateUsuarioRoles()
    {
        this.script = """
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
""";
    }
}
