using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMT
{
    public class PedidoTest
    {
        private HttpClient _client;
        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
        }
        [TearDown]
        public void Cleanup()
        {
            _client.Dispose();
        }
        [Test]
        public async Task ObtenerPedidos()
        {
            var response = await _client.GetAsync("http://localhost:5000/pedidos/");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("id_pedido"), Is.True, "El JSON no contiene id_pedido");
        }
        [Test]
        public async Task CrearPedido()
        {
            var json = "{\"id_pedido\": \"pruebaDelTestN3\",\r\n    \"id_cliente\": \"690D35EF-D847-47C8-BF0F-A7F7BADD28E1\",\r\n    \"dni_cliente\": \"12345678Z\",\r\n    \"nombre_cliente\": \"Federico\",\r\n    \"metodo_pago\": \"PayPal\",\r\n    \"fecha_creacion\": \"2026-04-30T11:38:59.4933333\",\r\n    \"fecha_envio\": \"2026-04-20T11:38:49.12\",\r\n    \"estado\": \"Cerrado\",\r\n    \"porcentaje_impuestos\": 21,\r\n    \"articulos\": []}";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:5000/pedidos", content);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            Assert.That(body.Contains("id_pedido"), Is.True);
            EliminarPedido();
        }
        [Test]
        public async Task CrearMismoPedido()
        {
            var json = "{\"id_pedido\": \"pruebaDelTestN3\",\r\n    \"id_cliente\": \"690D35EF-D847-47C8-BF0F-A7F7BADD28E1\",\r\n    \"dni_cliente\": \"12345678Z\",\r\n    \"nombre_cliente\": \"Federico\",\r\n    \"metodo_pago\": \"PayPal\",\r\n    \"fecha_creacion\": \"2026-04-30T11:38:59.4933333\",\r\n    \"fecha_envio\": \"2026-04-20T11:38:49.12\",\r\n    \"estado\": \"Cerrado\",\r\n    \"porcentaje_impuestos\": 21,\r\n    \"articulos\": []}";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("http://localhost:5000/pedidos", content);
            var response = await _client.PostAsync("http://localhost:5000/pedidos", content);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            EliminarPedido();
        }
        [Test]
        public async Task ObtenerPedidosPorNombreCliente()
        {
            var response = await _client.GetAsync("http://localhost:5000/pedidos?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);

            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
        }

        [Test]
        public async Task ObtenerPedidoPorId()
        {
            var response = await _client.GetAsync("http://localhost:5000/pedidos/pruebaDelTestN1");
            Assert.That(response.IsSuccessStatusCode, Is.True);

            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body.Contains("id_pedido"), Is.True);
        }

        [Test]
        public async Task ObtenerPorDniCliente()
        {
            var response = await _client.GetAsync("http://localhost:5000/pedidos/cliente?dni=12345678A");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task ObtenerArticulosPorPedido()
        {
            var response = await _client.GetAsync("http://localhost:5000/pedidos/pruebaDelTestN2/articulos");
            Assert.That(response.IsSuccessStatusCode, Is.True);

            var body = await response.Content.ReadAsStringAsync();
        }
        [Test]
        public async Task ActualizarPedido()
        {
            var json = "{\"id_pedido\":\"1\",\"id_cliente\":\"1\",\"dni_cliente\":\"12345678A\",\"metodo_pago\":\"Tarjeta\",\"fecha_rectificacion\":\"2024-01-02\",\"estado\":\"Enviado\",\"porcentaje_impuestos\":21,\"fecha_envio\":\"2024-01-03\",\"articulos\":[]}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("http://localhost:5000/pedidos/1", content);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task EliminarPedido()
        {
            var json = "{\"id_pedido\": \"pruebaDelTestN3\",\r\n    \"id_cliente\": \"690D35EF-D847-47C8-BF0F-A7F7BADD28E1\",\r\n    \"dni_cliente\": \"12345678Z\",\r\n    \"nombre_cliente\": \"Federico\",\r\n    \"metodo_pago\": \"PayPal\",\r\n    \"fecha_creacion\": \"2026-04-30T11:38:59.4933333\",\r\n    \"fecha_envio\": \"2026-04-20T11:38:49.12\",\r\n    \"estado\": \"Cerrado\",\r\n    \"porcentaje_impuestos\": 21,\r\n    \"articulos\": []}";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("http://localhost:5000/pedidos", content);

            var response = await _client.DeleteAsync("http://localhost:5000/pedidos/pruebaDelTestN3");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
