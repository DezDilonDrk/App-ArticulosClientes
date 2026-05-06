using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace TestProjectMT
{
    public class RolTest : BaseTest
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
        private async void BorrarRol(int id)
        {
            _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/roles/{id}");
        }
        [Test]
        public async Task ObtenerRoles()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/roles");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
        }
        [Test]
        public async Task ObtenerNombredeRoles()
        {
            try
            {
                var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/roles/nombres");
                Assert.That(response.IsSuccessStatusCode, Is.True);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Empty);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener nombres de roles: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerPorId()
        {
            try{Rol rol = new Rol(987, "RolPrueba", "Rol de prueba para test");
            var previo = await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/roles", rol);
            var creado = await previo.Content.ReadFromJsonAsync<Rol>();
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/roles/{creado.Id}");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            BorrarRol(creado.Id);} catch (Exception ex){
                Assert.Fail($"Excepción al obtener rol por ID: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearRol()
        {
            try{Rol rol = new Rol(987, "RolPrueba", "Rol de prueba para test");
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/roles", rol);
            var creado = await response.Content.ReadFromJsonAsync<Rol>();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarRol(creado.Id);}
            catch (Exception ex){
                Assert.Fail($"Excepción al crear rol: {ex.Message}");
            }
        }
        [Test]
        public async Task ActualizarRol()
        {
            try{Rol rol = new Rol(987, "RolPrueba", "Rol de prueba para test");
            var previo =await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/roles", rol);
            var creado = await previo.Content.ReadFromJsonAsync<Rol>();
            var response = await _client.PutAsJsonAsync($"{UrlMT.getUrl(currentServer)}/roles/{creado.Id}", rol);
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarRol(creado.Id);}
            catch (Exception ex){
                Assert.Fail($"Excepción al actualizar rol: {ex.Message}");
            }
        }
        [Test]
        public async Task EliminarRol()
        {
            try{Rol rol = new Rol(0, "RolPrueba2", "Rol de prueba para test");
            var previo = await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/roles", rol);
            var creado = await previo.Content.ReadFromJsonAsync<Rol>();
            Assert.That(creado.Id, Is.GreaterThan(0));
            var response = await _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/roles/{creado.Id}");
            Assert.That(response.IsSuccessStatusCode, Is.True);}
            catch (Exception ex){
                Assert.Fail($"Excepción al eliminar rol: {ex.Message}");
            }
        }
    }
}
