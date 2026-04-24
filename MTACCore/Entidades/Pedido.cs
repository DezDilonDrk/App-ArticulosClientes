using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class Pedido
    {
        public string id_pedido { get; set; }
        public string id_cliente { get; set; }
        public string dni_cliente { get; set; }
        public string metodo_pago { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_rectificacion { get; set; }
        public DateTime? fecha_envio { get; set; }
        //public enum EstadoPedido { Abierto, Cerrado, Cancelado }
        public string estado { get; set; }
        public double porcentaje_impuestos { get; set; }
        public string nombre_cliente { get; set; }
        public List<PedidoArticulos> articulos { get; set; } = new List<PedidoArticulos>();
        public Pedido() {}
        public Pedido(string id_cliente, string DniCliente, string MetodoPago, string Estado, double PorcentajeImpuestos, DateTime? FechaEnvio)
        {
            this.id_pedido = Guid.NewGuid().ToString();
            this.id_cliente = id_cliente;
            this.metodo_pago = MetodoPago;
            this.fecha_creacion = DateTime.Now;
            this.dni_cliente = DniCliente;
            this.fecha_envio = FechaEnvio;
            this.estado = Estado;
            this.porcentaje_impuestos = PorcentajeImpuestos;
        }
        public void cambiarLista(List<PedidoArticulos> articulos)
        {
            this.articulos = articulos;
        }
        public void ActualizarPedido(string DniCliente, string MetodoPago, double PorcentajeImpuestos, string Estado, List<PedidoArticulos> articulos, DateTime? FechaEnvio)
        {
            this.metodo_pago = MetodoPago;
            this.dni_cliente = DniCliente;
            this.porcentaje_impuestos = PorcentajeImpuestos;
            this.articulos = articulos;
            this.estado = Estado;
            this.fecha_envio = FechaEnvio;
            this.fecha_rectificacion = DateTime.Now;
        }
    }
}
