using MTCore_AC.DTO;
using System;
using System.Text;


namespace MTNegocios.Scripts;

public class PAK_2026601000000_InsertArticulos: Script
{
    public PAK_2026601000000_InsertArticulos()
    {
        var sb = new StringBuilder();

        var articulos = new List<(String nombre, decimal precio, String categoria, String? idDisenoCasco, DateTime fechaCreacion, DateTime? fechaActualizacion)>
        {
            ("Braker SV", 134.99m, "Cascos", null, DateTime.UtcNow, null),
            ("Thunder 4 R SV", 184.95m, "Cascos", null, DateTime.UtcNow, null),
            ("Chaqueta", 149.99m, "Ropa", null, DateTime.UtcNow, null),
            ("Pantalones", 89.99m, "Ropa", null, DateTime.UtcNow, null),
            ("Botas", 129.99m, "Ropa", null, DateTime.UtcNow, null),
            ("Visor solar", 29.99m, "Accesorios", null, DateTime.UtcNow, null),
            ("Intercomunicador", 53.69m, "Otros", null, DateTime.UtcNow, null)
        };
        foreach (var a in articulos)
        {
            var id = Guid.NewGuid().ToString();
            var nombre = a.nombre.Replace("'", "''");
            var categoria = a.categoria.Replace("'", "''");
            var precio = a.precio.ToString().Replace(",", ".");
            var idDisenoCasco = a.idDisenoCasco ?? "NULL";
            sb.AppendLine($@"INSERT INTO Articulos (Id, Nombre, Precio, Categoria, IdDisenoCasco, FechaCreacion, FechaActualizacion) VALUES ('{id}', '{nombre}', {precio}, '{categoria}', {idDisenoCasco}, '{a.fechaCreacion}', '{a.fechaActualizacion}');");
        }

        script = sb.ToString();

    }
}
