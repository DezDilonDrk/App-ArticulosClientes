using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class PedidoArticulos
    {
        // public int Id { get; set; } Su id realmente es orientativo en la base de datos (Actuando como PK), no tiene un papel real aquí
        public string id_pedido { get; set; }
        public int id_articulo { get; set; }
        public int cantidad { get; set; }
        public float precio_unidad { get; set; }
        public PedidoArticulos() {}
        public PedidoArticulos(string IdPedido, int IdArticulo, int Cantidad, float PrecioUnidad) {
            this.id_pedido = IdPedido;
            this.id_articulo = IdArticulo;   
            this.cantidad = Cantidad;
            this.precio_unidad = PrecioUnidad;
        }
    }
}
