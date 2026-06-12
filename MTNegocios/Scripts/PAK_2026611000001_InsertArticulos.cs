using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using MTNegocios.Repositorios.Almacen;
using System;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Connections;

namespace MTNegocios.Scripts;

public class PAK_2026611000001_InsertArticulos: Script
{
    public override async Task Execute(string connectionString)
    {  
        var articuloRepo = new ArticuloRepository(connectionString);

        var articulos = new List<Articulo>
        {
            new Articulo("Braker SV", 134.99m, "Cascos", null, DateTime.UtcNow, null),
            new Articulo("Thunder 4 R SV", 184.95m, "Cascos", null, DateTime.UtcNow, null),
            new Articulo("Chaqueta", 149.99m, "Ropa", null, DateTime.UtcNow, null),
            new Articulo("Pantalones", 89.99m, "Ropa", null, DateTime.UtcNow, null),
            new Articulo("Botas", 129.99m, "Ropa", null, DateTime.UtcNow, null),
            new Articulo("Visor solar", 29.99m, "Accesorios", null, DateTime.UtcNow, null),
            new Articulo("Intercomunicador", 53.69m, "Otros", null, DateTime.UtcNow, null)
        };

        foreach(var articulo in articulos)
        {
            await articuloRepo.Insertar(articulo);
        }
    }
}
