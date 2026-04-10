using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class Pedido
    {
        public string id_pedido { get; set; }
        public string dni_cliente { get; set; }
        public string metodo_pago { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_rectificacion { get; set; }
        public enum EstadoPedido { Abierto, Cerrado, Cancelado }
        public string estado { get; set; }
        public double porcentaje_impuestos { get; set; }
        public List<PedidoArticulos> articulos { get; set; } = new List<PedidoArticulos>();
        public Pedido() {}
        public Pedido(string DniCliente, string MetodoPago, double PorcentajeImpuestos)
        {
            this.id_pedido = Guid.NewGuid().ToString();
            this.metodo_pago = MetodoPago;
            this.fecha_creacion = DateTime.Now;
            this.dni_cliente = DniCliente;
            this.estado = EstadoPedido.Abierto.ToString();
            this.porcentaje_impuestos = PorcentajeImpuestos;
        }
        public void cambiarLista(List<PedidoArticulos> articulos)
        {
            this.articulos = articulos;
        }
        public void ActualizarPedido(string DniCliente, string MetodoPago, double PorcentajeImpuestos, string Estado, List<PedidoArticulos> articulos)
        {
            this.metodo_pago = MetodoPago;
            this.dni_cliente = DniCliente;
            this.porcentaje_impuestos = PorcentajeImpuestos;
            this.articulos = articulos;
            this.estado = Estado;
            this.fecha_rectificacion = DateTime.Now;
        }
    }
}
