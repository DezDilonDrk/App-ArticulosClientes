
using Microsoft.Data.SqlClient;

namespace MTNegocios.ConexionDB;

public class Builder
{
    public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    Conexion conexion = new Conexion();
    public Builder()    
    {
        builder.ConnectionString = conexion.conexionString;
    }
}
