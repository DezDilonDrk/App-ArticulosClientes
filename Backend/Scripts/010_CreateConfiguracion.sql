IF OBJECT_ID('Confirguracion', 'CF') IS NULL
BEGIN
CREATE TABLE Configuraciones(
	id_configuracion NVARCHAR(36) NOT NULL,
	correo_usuario VARCHAR(255) NOT NULL,
	config_json VARBINARY(max) NULL);
END