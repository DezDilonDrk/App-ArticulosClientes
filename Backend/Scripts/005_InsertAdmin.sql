IF NOT EXISTS(
	SELECT 1 FROM Usuarios
	WHERE CorreoElectronico = 'admin@mthelmets.com'
)
BEGIN
	INSERT INTO Usuarios (CorreoElectronico, NombreUsuario, Contrasena)
	VALUES (
		'admin@mthelmets.com',
		'Administrador',
		'$2a$11$8esi3nzFR5YRGsNkOxwy4.CqN7eSn3ICMDrHbTaUwi.2yI8IDt6Ci'
	)
END

IF NOT EXISTS(
	SELECT 1
	FROM UsuarioRoles ur
	JOIN Roles r ON ur.RolId = r.Id
	WHERE ur.UsuarioEmail = 'admin@mtehlmets.com'
	AND r.Nombre = 'ADMIN_SEGURIDAD'
)
BEGIN
	INSERT INTO UsuarioRoles (UsuarioEmail, RolId)
	SELECT 'admin@mthelmets.com', Id
	FROM Roles
	WHERE Nombre IN ('ADMIN_SEGURIDAD', 'ADMIN_ALMACEN', 'ADMIN_VENTAS')
END