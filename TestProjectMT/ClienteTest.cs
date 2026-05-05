using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using MTCore_AC.Entidades;
using SesionMT;

namespace TestProjectMT
{
    public class ClienteTest
    {
        private HttpClient _client;
        private string token = UserSession.token;
        private string currentServer = "local";
        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        [TearDown]
        public void Cleanup()
        {
            _client.Dispose();
        }
        private async void BorrarCliente(string dni)
        {
            _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/clientes/{dni}");
        }
        [Test]
        public async Task ObtenerClientes()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/clientes");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("id"), Is.True, "El JSON no contiene ningún Id de clientes");
        }
        [Test]
        public async Task BuscarClientePorNombre() {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/clientes?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
        }
        [Test]
        public async Task CrearCliente()
        {
            Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/clientes", cliente);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarCliente(cliente.Dni);
        }
        [Test]
        public async Task CrearMismoCliente()
        {
            Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/clientes", cliente);
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/clientes", cliente);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            BorrarCliente(cliente.Dni);
        }
        [Test]
        public async Task ObtenerClientePorDni()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/clientes/12345678Z");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body.Contains("id"), Is.True);
        }
        [Test]
        public async Task ActualizarCliente()
        {
            Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/clientes", cliente);
            var response = await _client.PutAsJsonAsync($"{UrlMT.getUrl(currentServer)}/clientes/{cliente.Dni}", cliente);
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarCliente(cliente.Dni);
        }

        [Test]
        public async Task EliminarCliente()
        {
            Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/clientes", cliente);
            var response = await _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/clientes/12345678A");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
