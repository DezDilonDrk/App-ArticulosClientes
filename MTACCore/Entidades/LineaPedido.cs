using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class LineaPedido
    {
        public string id_articulo { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }

        public decimal precioUnidad { get; set; }
        public int cantidad { get; set; }
        public decimal totalLinea { get; set; }
        public LineaPedido(string id_articulo, string nombre, string categoria, int cantidad, decimal precioUnidad)
        {
            this.id_articulo = id_articulo;
            this.nombre = nombre;
            this.categoria = categoria;
            this.cantidad = cantidad;
            this.precioUnidad = precioUnidad;
            calcularTotalLinea();
        }
        public void calcularTotalLinea()
        {
            totalLinea = precioUnidad * cantidad;
        }
    }
}
