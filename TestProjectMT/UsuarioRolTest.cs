using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace TestProjectMT
{
    public class UsuarioRolTest
    {
        private HttpClient _client;
        private string currentServer = "local";
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
        private async void BorrarRol(int id)
        {
            _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/roles/{id}");
        }
        [Test]
        public async Task ObtenerTodo()
        {
            try{var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/usuario-roles");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");}
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener roles de usuario: {ex.Message}");
            }
        [Test]
        public async Task ObtenerRolPorEmail()
        {
            try{string email = "leandro.santilario@mthelmets.com";
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/roles/usuario/{email}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);}
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener rol por email: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerRolPorId()
        {
            try{Rol rol = new Rol(987, "RolPrueba", "Rol de prueba para test");
            var previo = await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/roles", rol);
            var creado = await previo.Content.ReadFromJsonAsync<Rol>();
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/usuario-roles/rol/{creado.Id}");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            BorrarRol(rol.Id);} 
            catch (Exception ex){
                Assert.Fail($"Excepción al obtener rol por ID: {ex.Message}");
            }
        [Test]
        public async Task EliminarRoldeUsuario()
        {
            try {//UsuarioRol usuarioRol = new UsuarioRol(345, "flipanteemail@gmail.com"); Post no encontrado
            Rol rol = new Rol(0, "RolPrueba2", "Rol de prueba para test");
            string emailEjemplo = "ejemplooo12069023847@gmail.com";
            var previo = await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/roles", rol);
            var creado = await previo.Content.ReadFromJsonAsync<Rol>();
            Assert.That(creado.Id, Is.GreaterThan(0));
            var response = await _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/usuario-roles/{creado.Id}/{emailEjemplo}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarRol(creado.Id);} catch (Exception ex){
                Assert.Fail($"Excepción al eliminar rol de usuario: {ex.Message}");
            }
    }
}
