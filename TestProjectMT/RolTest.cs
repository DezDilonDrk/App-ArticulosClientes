using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace TestProjectMT
{
    public class RolTest
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
        private async void BorrarUsuario(string correo)
        {
            _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/usuarios/correo/{correo}");
        }
        [Test]
        public async Task ObtenerUsuarios()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/usuarios");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("correoElectronico"), Is.True, "El JSON no contiene ningún Correo de ningún usuario");
        }
        [Test]
        public async Task BuscarUsuarioPorNombre()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/usuarios?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
        }
        [Test]
        public async Task CrearUsuario()
        {
            Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/usuarios", usuario);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarUsuario(usuario.CorreoElectronico);
        }
        [Test]
        public async Task CrearMismoUsuario()
        {
            Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/usuarios", usuario);
            var response = await _client.PostAsJsonAsync($"{UrlMT.getUrl(currentServer)}/usuarios", usuario);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            Assert.That(response.IsSuccessStatusCode, Is.False);
            BorrarUsuario(usuario.CorreoElectronico);
        }
        [Test]
        public async Task ObtenerRolesUsuario()
        {
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/usuarios/leandro.santilario@mthelmets.com/roles");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
        }
        [Test]
        public async Task ObtenerUsuarioPorCorreo()
        {
            Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/usuarios", usuario);
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/usuarios/correo/{usuario.CorreoElectronico}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            BorrarUsuario(usuario.CorreoElectronico);
        }
        [Test]
        public async Task ObtenerUsuarioPorNombre()
        {
            Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/usuarios", usuario);
            var response = await _client.GetAsync($"{UrlMT.getUrl(currentServer)}/usuarios/nombre/{usuario.Nombre}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            BorrarUsuario(usuario.CorreoElectronico);
        }
        [Test]
        public async Task ActualizarUsuarioCompleto()
        {
            Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/usuarios", usuario);
            var response = await _client.PutAsJsonAsync($"{UrlMT.getUrl(currentServer)}/usuarios", usuario);
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarUsuario(usuario.CorreoElectronico);
        }
        [Test]
        public async Task ActualizarContrasenaUsuario()
        {
            Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/usuarios", usuario);
            string nuevaContrasena = "nuevaContraseña123";
            var response = await _client.PutAsJsonAsync($"{UrlMT.getUrl(currentServer)}/usuarios/{usuario.CorreoElectronico}/contrasena", new { NuevaContrasena = nuevaContrasena });
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarUsuario(usuario.CorreoElectronico);
        }
        [Test]
        public async Task ActualizarRolesUsuario()
        {
            Usuario usuario = new Usuario("prueba@correo.com", "Fausto", "contraseña123");
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/usuarios", usuario);
            List<string> roles = new List<string>();
            var response = await _client.PutAsJsonAsync($"{UrlMT.getUrl(currentServer)}/usuarios/{usuario.CorreoElectronico}/roles", roles);
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarUsuario(usuario.CorreoElectronico);
        }

        [Test]
        public async Task EliminarUsuario()
        {
            Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await _client.PostAsJsonAsync($"{UrlMT.getUrl("local")}/usuarios", usuario);
            var response = await _client.DeleteAsync($"{UrlMT.getUrl(currentServer)}/usuarios/correo/{usuario.CorreoElectronico}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }
    }
}
