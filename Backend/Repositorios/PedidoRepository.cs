using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.Entidades;
using System.Data;
namespace Articulos_Backend.Repositorios

{
    public class PedidoRepository
    {
        private readonly string _connectionString;
        public PedidoRepository(string connectionString = null)
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);
        public List<Pedido> ObtenerPedidos()
        {
            using (var db = Connection)
            {
                string sql = "SELECT id_pedido, dni_cliente, metodo_pago, fecha_creacion, fecha_rectificacion, estado, porcentaje_impuestos FROM Pedidos";
                return db.Query<Pedido>(sql).ToList();
            }
        }
        public Pedido ObtenerPorId(int id)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE id_pedido = @IdPedido";
                return db.QueryFirstOrDefault<Pedido>(sql, new { IdPedido = id });
            }
        }
        public List<Pedido> ObtenerPorDniCliente(string dni)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE dni_cliente = @DniCliente";
                return db.Query<Pedido>(sql, new { DniCliente = dni }).ToList();
            }
        }
        public Pedido ObtenerPorIdArticulo(int id)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE id_articulo = @IdArticulo";
                return db.QueryFirstOrDefault<Pedido>(sql, new { IdArticulo = id });
            }
        }
        public List<Pedido> ObtenerPorEstado(string estado)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE estado = @Estado";
                return db.Query<Pedido>(sql, new { Estado = estado }).ToList();
            }
        }
        public void Insertar(Pedido pedido)
        {
            using (var db = Connection)
            {
                string sql = @"INSERT INTO Pedidos (id_pedido, dni_cliente, metodo_pago, fecha_creacion, estado, porcentaje_impuestos)
                           VALUES (@IdPedido, @DniCliente, @MetodoPago, @FechaCreacion, @Estado, @PorcentajeImpuestos)";
                db.Execute(sql, pedido);
            }
        }
        public void Actualizar(Pedido pedido)
        {
            using (var db = Connection)
            {
                string sql = @"UPDATE Pedidos
                               SET dni_cliente = @DniCliente, 
                               metodo_pago = @MetodoPago,
                               fecha_rectificacion = @FechaRectificacion, 
                               estado = @Estado, 
                               porcentaje_impuestos = @PorcentajeImpuestos  
                               WHERE id_pedido = @IdPedido";

                db.Execute(sql, pedido);
            }
        }
        public void Eliminar(int id)
        {
            using (var db = Connection)
            {
                string sql = "DELETE FROM Pedidos WHERE id_pedido = @IdPedido";

                db.Execute(sql, new { IdPedido = id });
            }
        }
    }
}
