using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class PedidoArticulos
    {
        // public int Id { get; set; } Su id realmente es orientativo en la base de datos (Actuando como PK), no tiene un papel real aquí
        public string IdPedido { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public PedidoArticulos(string IdPedido, int IdArticulo, int Cantidad) {
            this.IdPedido = IdPedido;
            this.IdArticulo = IdArticulo;   
            this.Cantidad = Cantidad;
        }
    }
}
