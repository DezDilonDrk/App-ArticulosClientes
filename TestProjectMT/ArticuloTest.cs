using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace TestProjectMT
{
    public class ArticuloTest : BaseTest
    {
        [SetUp]
        public async Task Setup()
        {
           await UserSession.GenerateToken();
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", UserSession.token);
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
            try { var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/articulos");
                Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
                Assert.That(body.Contains("id"), Is.True, "El JSON no contiene ningún Id de articulos");
            } catch (Exception ex) {
                Assert.Fail($"Excepción al obtener artículos: {ex.Message}");
            }
        }
        [Test]
        public async Task BuscarArticuloPorNombre()
        {
            try {var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/articulos?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
            } catch (Exception ex){
                Assert.Fail($"Excepción al buscar artículo por nombre: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearArticulo()
        {
            try { Articulo articulo = await NewArticulo();
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarArticulo(articulo.id);
            } catch (Exception ex){
                Assert.Fail($"Excepción al crear artículos: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearMismoArticulo()
        {
            try
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
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al crear el mismo artículo: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerClientePorDni()
        {
            try {var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/clientes/12345678Z");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body.Contains("id"), Is.True);
            } catch (Exception ex){
                Assert.Fail($"Excepción al obtener cliente por DNI: {ex.Message}");
            }
        }
        [Test]
        public async Task ActualizarArticulo() //TO DO solo queda el problema del id = 0
        {
            try {Articulo articulo = await NewArticulo();
            await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            var response = await _client.PutAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos/{articulo.id}", articulo);
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarArticulo(articulo.id);
            } catch (Exception ex){
                Assert.Fail($"Excepción al actualizar artículo: {ex.Message}");
            }
        }

        [Test]
        public async Task EliminarArticulo() //TO DO solo queda el problema del id = 0
        {
            try {Articulo articulo = await NewArticulo();
            var created = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/articulos", articulo);
            Assert.That(created.IsSuccessStatusCode, Is.True);
            var response = await _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/articulos/{articulo.id}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            } catch (Exception ex){
                Assert.Fail($"Excepción al eliminar artículo: {ex.Message}");
            }
        }
    }
}
