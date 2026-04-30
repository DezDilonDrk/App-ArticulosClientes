using NUnit.Framework;
using System.Net.Http;
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
        public async Task ObtenerPedido()
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
            var json = "{\"id_pedido\": \"1a0ef994-1346-418c-95f7-8f980103a097\",\r\n    \"id_cliente\": \"690D35EF-D847-47C8-BF0F-A7F7BADD28E1\",\r\n    \"dni_cliente\": \"12345678Z\",\r\n    \"nombre_cliente\": \"Federico\",\r\n    \"metodo_pago\": \"PayPal\",\r\n    \"fecha_creacion\": \"2026-04-20T11:38:59.4933333\",\r\n    \"fecha_rectificacion\": \"2026-04-20T12:17:40.3033333\",\r\n    \"fecha_envio\": \"2026-04-20T11:38:49.12\",\r\n    \"estado\": \"Cerrado\",\r\n    \"porcentaje_impuestos\": 21,\r\n    \"articulos\": []}";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:5000/pedidos", content);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            Assert.That(body.Contains("id_pedido"), Is.True);
        }
    }
}
