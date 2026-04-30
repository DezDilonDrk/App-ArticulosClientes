using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectMT
{
    public class ClienteTest
    {
        private HttpClient _client;
        private string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibGVhbmRyby5zYW50aWxhcmlvQG10aGVsbWV0cy5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOlsiQURNSU5fQUxNQUNFTiIsIkFETUlOX1ZFTlRBUyIsIkFETUlOX1NFR1VSSURBRCJdLCJleHAiOjE3Nzc1NTU5NDZ9.Yygp9gz3nwtgoUntDGD6G4goDvQocwmrufZLLUrluRg";

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
        public async Task ObtenerClientes()
        {
            _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync("http://localhost:5000/clientes");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("id"), Is.True, "El JSON no contiene ningún Id de clientes");
        }
        [Test]
        public async Task CrearCliente()
        {
            _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = ""; //TO DO
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:5000/pedidos", content);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            Assert.That(body.Contains("id_pedido"), Is.True);
            EliminarCliente();
        }
        [Test]
        public async Task CrearMismoCliente()
        {
            _client.DefaultRequestHeaders.Authorization =
           new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = "";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json"); //TO DO
            await _client.PostAsync("http://localhost:5000/pedidos", content);
            var response = await _client.PostAsync("http://localhost:5000/pedidos", content);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            EliminarCliente();
        }
        [Test]
        public async Task ObtenerClientePorDni()
        {
            _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = "{\"id_pedido\": \"pruebaDelTestN3\",\r\n    \"id_cliente\": \"690D35EF-D847-47C8-BF0F-A7F7BADD28E1\",\r\n    \"dni_cliente\": \"12345678Z\",\r\n    \"nombre_cliente\": \"Federico\",\r\n    \"metodo_pago\": \"PayPal\",\r\n    \"fecha_creacion\": \"2026-04-30T11:38:59.4933333\",\r\n    \"fecha_envio\": \"2026-04-20T11:38:49.12\",\r\n    \"estado\": \"Cerrado\",\r\n    \"porcentaje_impuestos\": 21,\r\n    \"articulos\": []}";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _client.GetAsync("http://localhost:5000/clientes/12345678Z");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body.Contains("id"), Is.True);
        }
        [Test]
        public async Task ActualizarCliente() //TO DO
        {
            var json = "";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("http://localhost:5000/pedidos/1", content);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test] //TO DO
        public async Task EliminarCliente()
        {
            var json = "";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await _client.PostAsync("http://localhost:5000/pedidos", content);

            var response = await _client.DeleteAsync("http://localhost:5000/pedidos/pruebaDelTestN3");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
