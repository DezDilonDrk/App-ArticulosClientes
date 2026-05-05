using MTCore_AC.Entidades;
using NUnit.Framework;
using SesionMT;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMT
{
    public class PedidoTest
    {
        private HttpClient _client;
        private string currentServer = "local";
        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
        }
        private async Task<Pedido> NewPedido() {
            Pedido pedido = new Pedido("690D35EF-D847-47C8-BF0F-A7F7BADD28E1", "12345678A", "Fausterico", "PruebaPal", "Abierto", 21, DateTime.Now);
            return pedido; 
        }
        private async void BorrarPedido(string id_pedido)
        {
            _client.DeleteAsync($"{UrlMT.getUrl("local")}/pedidos/{id_pedido}");
        }
        [TearDown]
        public void Cleanup()
        {
            _client.Dispose();
        }
        [Test]
        public async Task ObtenerPedidos()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/pedidos/");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("id_pedido"), Is.True, "El JSON no contiene id_pedido");
        }
        [Test]
        public async Task CrearPedido()
        {
            Pedido pedido = await NewPedido();
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/pedidos", pedido);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            Assert.That(body.Contains("id_pedido"), Is.True);
            BorrarPedido(pedido.id_pedido);
        }
        [Test]
        public async Task CrearMismoPedido()
        {
            Pedido pedido = new Pedido("690D35EF-D847-47C8-BF0F-A7F7BADD28E1", "12345678A", "Fausterico", "PruebaPal", "Abierto", 21, DateTime.Now);
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/pedidos", pedido);
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/pedidos", pedido);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarPedido(pedido.id_pedido);
        }
        [Test]
        public async Task ObtenerPedidosPorNombreCliente()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/pedidos?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
        }
        [Test]
        public async Task ObtenerPedidoPorId()
        {
            Pedido pedido = await NewPedido();
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/pedidos", pedido);
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/pedidos/{pedido.id_pedido}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body.Contains("id_pedido"), Is.True);
            BorrarPedido(pedido.id_pedido);
        }
        [Test]
        public async Task ObtenerPorDniCliente()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/pedidos/cliente?dni=12345678A");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
        }

        [Test]
        public async Task ObtenerArticulosPorPedido()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/pedidos/pruebaDelTestN2/articulos");
            Assert.That(response.IsSuccessStatusCode, Is.True);

            var body = await response.Content.ReadAsStringAsync();
        }
        [Test]
        public async Task ActualizarPedido()
        {
            Pedido pedido = new Pedido("690D35EF-D847-47C8-BF0F-A7F7BADD28E1", "12345678A", "Fausterico", "PruebaPal", "Abierto", 21, DateTime.Now);
            await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/pedidos", pedido);
            var json = "{\"id_pedido\":\"pruebaDelTestN3\",\"id_cliente\":\"690D35EF-D847-47C8-BF0F-A7F7BADD28E1\",\"dni_cliente\":\"12345678A\",\"metodo_pago\":\"Tarjeta\",\"fecha_rectificacion\":\"2024-01-02\",\"estado\":\"Enviado\",\"porcentaje_impuestos\":21,\"fecha_envio\":\"2024-01-03\",\"articulos\":[]}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{UrlMT.getUrl(currentServer)}/pedidos/1", content);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarPedido(pedido.id_pedido);
        }
        [Test]
        public async Task EliminarPedido()
        {
            Pedido pedido = await NewPedido();
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/pedidos", pedido);
            var response = await _client.DeleteAsync($"{UrlMT.getUrl("local")}/pedidos/{pedido.id_pedido}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}