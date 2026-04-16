using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class PedidoArticulos
    {
        public string id_pedido { get; set; }
        public int id_articulo { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unidad { get; set; }
        public PedidoArticulos() {}
        public PedidoArticulos(string IdPedido, int IdArticulo, int Cantidad, decimal PrecioUnidad) {
            this.id_pedido = IdPedido;
            this.id_articulo = IdArticulo;   
            this.cantidad = Cantidad;
            this.precio_unidad = PrecioUnidad;
        }
    }
}
