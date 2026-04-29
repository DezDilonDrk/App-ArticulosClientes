using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.DTO;

public class SqlQueries
{
    public const string ScriptExiste = "SELECT COUNT(1) FROM ScriptEjecutados WHERE NombreScript = @Nombre";
    public const string InsertScript = "INSERT INTO ScriptEjecutados (NombreScript) VALUES (@Nombre)";
    public const string CrearTablaScript = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ScriptEjecutados')
                          CREATE TABLE ScriptEjecutados (
                              Id INT IDENTITY PRIMARY KEY,
                              NombreScript NVARCHAR(255),
                              FechaEjecucion DATETIME DEFAULT GETDATE()
                          )";
    public const string SelectScript = "SELECT NombreScript, FechaEjecucion FROM ScriptEjecutados";
}
