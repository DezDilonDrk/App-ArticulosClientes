
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

namespace MTNegocios.ConexionDB;

public class Builder
{
    public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
    public Builder()    
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: false).Build();
        builder.ConnectionString = config.GetConnectionString("DefaultConnection");
    }
}
