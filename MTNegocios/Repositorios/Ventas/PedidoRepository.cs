using Dapper;
using Microsoft.Data.SqlClient;
using MTCore_AC.Entidades;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace MTNegocios.Repositorios.Ventas

{
    public class PedidoRepository
    {
        private readonly string _connectionString;
        public PedidoRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);
        public async Task<List<Pedido>> ObtenerPedidos()
        {
            using (var db = Connection)
            {
                string sql = "SELECT id_pedido, id_cliente, dni_cliente, nombre_cliente, metodo_pago, fecha_creacion, fecha_rectificacion, fecha_envio, estado, porcentaje_impuestos FROM Pedidos";
                return (await db.QueryAsync<Pedido>(sql)).ToList();
            }
        }
        public async Task<Pedido> ObtenerPorId(string id)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE id_pedido = @IdPedido";
                return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { IdPedido = id });
            }
        }
        public async Task<List<Pedido>> BuscarPorNombreCliente(string Nombre)
        {
            using (var db = Connection)
            {
                string sql = @"SELECT id_pedido, id_cliente, dni_cliente, nombre_cliente, metodo_pago, fecha_creacion, fecha_rectificacion, fecha_envio, estado, porcentaje_impuestos
                               FROM Pedidos
                               WHERE nombre_cliente LIKE @Nombre";

                return (await db.QueryAsync<Pedido>(sql, new { Nombre = $"%{Nombre}%" })).ToList();
            }
        }
        public async Task<List<Pedido>> ObtenerPorDniCliente(string dni)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE dni_cliente = @DniCliente";
                return (await db.QueryAsync<Pedido>(sql, new { DniCliente = dni })).ToList();
            }
        }
        public async Task<Pedido> ObtenerPorIdArticulo(string id)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE id_articulo = @IdArticulo";
                return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { IdArticulo = id });
            }
        }
        public async Task<List<Pedido>> ObtenerPorEstado(string estado)
        {
            using (var db = Connection)
            {
                string sql = "SELECT * FROM Pedidos WHERE estado = @Estado";
                return (await db.QueryAsync<Pedido>(sql, new { Estado = estado })).ToList();
            }
        }
        public async Task Insertar(Pedido pedido)
        {
            using (var db = Connection)
            {
                string sql = @"INSERT INTO Pedidos (id_pedido, id_cliente,  dni_cliente, nombre_cliente, metodo_pago, fecha_creacion, estado, porcentaje_impuestos, fecha_envio)
                           VALUES (@id_pedido, @id_cliente, @dni_cliente, @nombre_cliente, @metodo_pago, @fecha_creacion, @estado, @porcentaje_impuestos, @fecha_envio)";
                await db.ExecuteAsync(sql, pedido);
            }
        }
        public async Task Actualizar(Pedido pedido)
        {
            using (var db = Connection)
            {
                string sql = @"UPDATE Pedidos
                               SET id_cliente = @id_cliente,
                               nombre_cliente = @nombre_cliente,
                               dni_cliente = @dni_cliente, 
                               metodo_pago = @metodo_pago,
                               fecha_rectificacion = @fecha_rectificacion, 
                               estado = @estado, 
                               porcentaje_impuestos = @porcentaje_impuestos,
                               fecha_envio = @fecha_envio
                               WHERE id_pedido = @id_pedido";
                await db.ExecuteAsync(sql, pedido);
                string sql2 = @"DELETE FROM Pedido_Articulos WHERE id_pedido = @id_pedido";
                await db.ExecuteAsync(sql2, pedido);
                foreach (var articulo in pedido.articulos)
                {
                    string sql3 = @"INSERT INTO Pedido_Articulos (id_pedido, id_articulo, cantidad, precio_unidad) VALUES (@id_pedido,@id_articulo, @cantidad, @precio_unidad)";
                    await db.ExecuteAsync(sql3, articulo);
                }
            }
        }
        public async Task Eliminar(string id)
        {
            using (var db = Connection)
            {
                string sql = $"DELETE FROM Pedido_Articulos WHERE id_pedido = @IdPedido";
                string sql2 = $"DELETE FROM Pedidos WHERE id_pedido = @IdPedido";
                await db.ExecuteAsync(sql, new { IdPedido = id });
                await db.ExecuteAsync(sql2, new { IdPedido = id });
            }
        }
        public async Task AgregarArticulo(PedidoArticulos articulo)
        {
            using (var db = Connection)
            {
                string sql = $"INSERT INTO Pedido_Articulos (id_pedido, id_articulo, cantidad, precio_unidad) VALUES (@id_pedido,@id_articulo, @cantidad, @precio_unidad)";
                await db.ExecuteAsync(sql, articulo);
            }
        }
        public async Task EliminarArticulo(PedidoArticulos articulo)
        {
            using (var db = Connection)
            {
                string sql = $"DELETE FROM Pedido_Articulos WHERE id_pedido = @id_pedido AND id_articulo = @id_articulo";
                await db.ExecuteAsync(sql, articulo);
            }
        }
        public async Task<List<PedidoArticulos>> ObtenerArticulosPorPedido(string idPedido)
        {
            using (var db = Connection)
            {
                string sql = $"SELECT id_pedido, id_articulo, cantidad, precio_unidad FROM Pedido_Articulos WHERE id_pedido = @IdPedido";
                return (await db.QueryAsync<PedidoArticulos>(sql, new { IdPedido = idPedido })).ToList();
            }
        }
    }
}
