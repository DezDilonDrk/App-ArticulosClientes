using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace TestProjectMT
{
    public class ArticuloTest
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
        private async Task<Articulo> NewArticulo()
        {
            Articulo articulo = new Articulo("ArticuloPrueba1", 920384, "prueba", DateTime.Now, null);
            return articulo;
        }
        private async void BorrarArticulo(string id)
        {
            _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/articulos/{id}");
        }
        [Test]
        public async Task ObtenerArticulos()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/articulos");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("id"), Is.True, "El JSON no contiene ningún Id de articulos");
        }
        [Test]
        public async Task BuscarArticuloPorNombre()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/articulos?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
        }
        [Test]
        public async Task CrearArticulo()
        {
            Articulo articulo = await NewArticulo();
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarArticulo(articulo.id);
        }
        [Test]
        public async Task CrearMismoArticulo()
        {
            Articulo articulo = await NewArticulo();
            await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            BorrarArticulo(articulo.id);
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
        public async Task ActualizarArticulo() //TO DO solo queda el problema del id = 0
        {
            Articulo articulo = await NewArticulo();
            await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            var response = await _client.PutAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos/{articulo.id}", articulo);
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarArticulo(articulo.id);
        }

        [Test]
        public async Task EliminarArticulo() //TO DO solo queda el problema del id = 0
        {
            Articulo articulo = await NewArticulo();
            var created = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            Assert.That(created.IsSuccessStatusCode, Is.True);
            var response = await _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/articulos/{articulo.id}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
