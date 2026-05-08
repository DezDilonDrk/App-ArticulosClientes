using MTCore_AC.Entidades;
using NUnit.Framework;
using SesionMT;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMT
{
    public class PedidoTest : BaseTest
    {
		string currentServer = "";
		[OneTimeSetUp]
		public async Task Setup()
        {
            await this.Init(UrlMT.serverLocal);
		}
        private async Task<Pedido> NewPedido() {
            Pedido pedido = new Pedido("690D35EF-D847-47C8-BF0F-A7F7BADD28E1", "12345678A", "Fausterico", "PruebaPal", "Abierto", 21, DateTime.Now);
            return pedido; 
        }
        private async void BorrarPedido(string id_pedido)
        {
            this.mySession.GetClient().DeleteAsync($"/pedidos/{id_pedido}");
        }
        [Test]
        public async Task ObtenerPedidos()
        {
            try{var response = await this.mySession.GetClient().GetAsync($"/pedidos/");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("id_pedido"), Is.True, "El JSON no contiene id_pedido");
            } catch (Exception ex){
                Assert.Fail($"Excepción al obtener pedidos: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearPedido()
        {
            try { Pedido pedido = await NewPedido();
                var response = await this.mySession.GetClient().PostAsJsonAsync($"/pedidos", pedido);
                Assert.That(response.IsSuccessStatusCode, Is.True);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty);
                Assert.That(body.Contains("id_pedido"), Is.True);
                BorrarPedido(pedido.id_pedido); }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al crear pedido: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearMismoPedido()
        {
            try{Pedido pedido = new Pedido("690D35EF-D847-47C8-BF0F-A7F7BADD28E1", "12345678A", "Fausterico", "PruebaPal", "Abierto", 21, DateTime.Now);
            await this.mySession.GetClient().PostAsJsonAsync($"/pedidos", pedido);
            var response = await this.mySession.GetClient().PostAsJsonAsync($"/pedidos", pedido);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarPedido(pedido.id_pedido);
            } catch (Exception ex){
                Assert.Fail($"Excepción al crear el mismo pedido: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerPedidosPorNombreCliente()
        {
            try{var response = await this.mySession.GetClient().GetAsync($"/pedidos?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
            } catch (Exception ex){
                Assert.Fail($"Excepción al obtener pedidos por nombre de cliente: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerPedidoPorId()
        {
            try { Pedido pedido = await NewPedido();
                await this.mySession.GetClient().PostAsJsonAsync($"/pedidos", pedido);
                var response = await this.mySession.GetClient().GetAsync($"/pedidos/{pedido.id_pedido}");
                Assert.That(response.IsSuccessStatusCode, Is.True);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body.Contains("id_pedido"), Is.True);
                BorrarPedido(pedido.id_pedido);
            } catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener pedido por ID: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerPorDniCliente()
        {
            try{var response = await this.mySession.GetClient().GetAsync($"/pedidos/cliente?dni=12345678A");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            } catch (Exception ex){
                Assert.Fail($"Excepción al obtener pedidos por DNI de cliente: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerArticulosPorPedido()
        {
            try{var response = await this.mySession.GetClient().GetAsync($"/pedidos/pruebaDelTestN2/articulos");
            Assert.That(response.IsSuccessStatusCode, Is.True);

            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            } catch (Exception ex){
                Assert.Fail($"Excepción al obtener artículos por pedido: {ex.Message}");
            }
        }
        [Test]
        public async Task ActualizarPedido()
        {
            try
            {
                Pedido pedido = new Pedido("690D35EF-D847-47C8-BF0F-A7F7BADD28E1", "12345678A", "Fausterico", "PruebaPal", "Abierto", 21, DateTime.Now);
                await this.mySession.GetClient().PostAsJsonAsync($"/pedidos", pedido);
                var json = "{\"id_pedido\":\"pruebaDelTestN3\",\"idthis.mySession.GetClient()e\":\"690D35EF-D847-47C8-BF0F-A7F7BADD28E1\",\"dnithis.mySession.GetClient()e\":\"12345678A\",\"metodo_pago\":\"Tarjeta\",\"fecha_rectificacion\":\"2024-01-02\",\"estado\":\"Enviado\",\"porcentaje_impuestos\":21,\"fecha_envio\":\"2024-01-03\",\"articulos\":[]}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this.mySession.GetClient().PutAsync($"/pedidos/1", content);
                Assert.That(response.IsSuccessStatusCode, Is.True);
                BorrarPedido(pedido.id_pedido);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al actualizar pedido: {ex.Message}");
            }
        }
        [Test]
        public async Task EliminarPedido()
        {
            try{Pedido pedido = await NewPedido();
            await this.mySession.GetClient().PostAsJsonAsync($"/pedidos", pedido);
            var response = await this.mySession.GetClient().DeleteAsync($"/pedidos/{pedido.id_pedido}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            } catch (Exception ex){
                Assert.Fail($"Excepción al eliminar pedido: {ex.Message}");
            }
        }
    }
}