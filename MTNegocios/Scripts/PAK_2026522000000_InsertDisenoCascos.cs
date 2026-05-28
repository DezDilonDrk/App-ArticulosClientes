using MTCore_AC.DTO;
using System;
using System.Text;

namespace MTNegocios.Scripts;

public class PAK_2026522000000_InsertDisenoCascos: Script
{
    string id = Guid.NewGuid().ToString();
    public PAK_2026522000000_InsertDisenoCascos()
    {
        var sb = new StringBuilder();

        var disenos = new List<(string nombre, string descripcion)>
        {
            ("PURE A1 MATE", "Diseño de casco con acabado mate, ideal para quienes buscan un estilo sobrio y elegante."),
            ("PURE A1 BRILLO", "Diseño de casco con acabado brillante, perfecto para quienes desean un look más llamativo y moderno."),
            ("PURE A2 MATE", "Diseño de casco con acabado mate, ideal para quienes buscan un estilo sobrio y elegante."),
            ("STRANGE C4 MATE", "Diseño de casco con acabado mate y patrón peculiar pero estético"),
            ("STRANGE B2 BRILLO", "Diseño de casco con acabado brillante y patrón peculiar pero estético"),
            ("RACOON B12 BRILLO", "Diseño de casco con acabado brillante y patrón de mapache, ideal para quienes buscan un estilo divertido y único."),
            ("RACOON B5 MATE", "Diseño de casco con acabado mate y patrón de mapache, perfecto para quienes desean un look divertido pero más discreto."),
            ("DESTINY C6 MATE", "Diseño de casco con acabado mate y patrón agresivo, ideal para quienes buscan un estilo audaz y moderno."),
            ("STROKE B7 BRILLO", "Diseño de casco con acabado brillante y patrón de rayas, perfecto para quienes desean un look dinámico y deportivo."),
            ("STROKE B13 MATE", "Diseño de casco con acabado mate y patrón de rayas, ideal para quienes buscan un estilo dinámico pero más discreto."),
            ("DEXTER C2 MATE", "Diseño de casco con acabado mate y patrón de líneas asimétricas, ideal para quienes buscan un estilo moderno y vanguardista."),
            ("DEXTER B15 BRILLO", "Diseño de casco con acabado brillante y patrón de líneas asimétricas, perfecto para quienes desean un look moderno y llamativo."),
            ("HIGHLANDS C6 MATE", "Diseño de casco con acabado mate y patrón de montañas, ideal para quienes buscan un estilo aventurero y natural."),
            ("HIGHLANDS C2 BRILLO", "Diseño de casco con acabado brillante y patrón de montañas, perfecto para quienes desean un look aventurero pero más llamativo.")
        };

        foreach (var d in disenos)
        {
            var id = Guid.NewGuid().ToString();
            var nombre = d.nombre.Replace("'", "''");
            var descripcion = d.descripcion.Replace("'", "''");
            sb.AppendLine($@"
IF NOT EXISTS (SELECT * FROM DisenoCascos WHERE Id = '{id}')
BEGIN
INSERT INTO DisenoCascos (Id, Nombre, Descripcion) VALUES ('{id}', '{nombre}', '{descripcion}')
END");
        }

        script = sb.ToString();
    }
}
