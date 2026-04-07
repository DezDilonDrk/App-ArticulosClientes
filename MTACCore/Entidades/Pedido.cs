using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public string DniCliente { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaRectificacion { get; set; }
        public enum EstadoPedido { Abierto, Cerrado, Cancelado }
        public string Estado { get; set; }
        public double PorcentajeImpuestos { get; set; }
        public List<PedidoArticulos> articulos { get; set; }
        public Pedido() { }
        public Pedido(int idPedido, string DniCliente, string MetodoPago, DateTime FechaCreacion, double PorcentajeImpuestos, List<PedidoArticulos> articulos)
        {
            this.IdPedido = idPedido;
            this.FechaCreacion = DateTime.Now;
            this.DniCliente = DniCliente;
            Estado = EstadoPedido.Abierto.ToString();
            this.PorcentajeImpuestos = PorcentajeImpuestos;
            this.articulos = articulos;
        }
    }
}
