using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace TestProjectMT
{
    public class UsuarioTest : BaseTest
    {
		string currentServer = "";
		[OneTimeSetUp]
		public async Task Setup()
        {
            await this.Init(UrlMT.serverLocal);
		}
        private async void BorrarUsuario(string correo)
        {
            this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{correo}");
        }
        [Test]
        public async Task ObtenerUsuarios()
        {
            try{var response = await this.mySession.GetClient().GetAsync($"/usuarios");
            Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
            Assert.That(body.Contains("correoElectronico"), Is.True, "El JSON no contiene ningún Correo de ningún usuario");
            } catch (Exception ex){
                Assert.Fail($"Excepción al obtener usuarios: {ex.Message}");
            }
        }
        [Test]
        public async Task BuscarUsuarioPorNombre()
        {
            try{var response = await this.mySession.GetClient().GetAsync($"/usuarios?Nombre=Federico");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);
            } catch (Exception ex){
                Assert.Fail($"Excepción al buscar usuario por nombre: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearUsuario()
        {
            try{Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            var response = await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Null.And.Not.Empty);
            BorrarUsuario(usuario.CorreoElectronico);
            } catch (Exception ex){
                Assert.Fail($"Excepción al crear usuario: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearMismoUsuario()
        {
            try { Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
                await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
                var response = await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
                Assert.That(response.IsSuccessStatusCode, Is.False);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty);
                Assert.That(response.IsSuccessStatusCode, Is.False);
                BorrarUsuario(usuario.CorreoElectronico); }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al crear el mismo usuario: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerRolesUsuario()
        {
            try{var response = await this.mySession.GetClient().GetAsync($"/usuarios/leandro.santilario@mthelmets.com/roles");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();}
            catch (Exception ex){
                Assert.Fail($"Excepción al obtener roles de usuario: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerUsuarioPorCorreo()
        {
            try{Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
            var response = await this.mySession.GetClient().GetAsync($"/usuarios/correo/{usuario.CorreoElectronico}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            BorrarUsuario(usuario.CorreoElectronico);}
            catch (Exception ex){
                Assert.Fail($"Excepción al obtener usuario por correo: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerUsuarioPorNombre()
        {
            try{Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
            var response = await this.mySession.GetClient().GetAsync($"/usuarios/nombre/{usuario.Nombre}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            BorrarUsuario(usuario.CorreoElectronico);}
            catch (Exception ex){
                Assert.Fail($"Excepción al obtener usuario por nombre: {ex.Message}");
            }
        }
        [Test]
        public async Task ActualizarUsuarioCompleto()
        {
            try{Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/usuarios", usuario);
            response.EnsureSuccessStatusCode();
            Assert.That(response.IsSuccessStatusCode, Is.True);
            BorrarUsuario(usuario.CorreoElectronico);}
            catch (Exception ex){
                Assert.Fail($"Excepción al actualizar usuario completo: {ex.Message}");
            }
        }
        [Test]
        public async Task ActualizarContrasenaUsuario()
        {
            try { Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
                await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
                string nuevaContrasena = "nuevaContraseña123";
                var response = await this.mySession.GetClient().PutAsJsonAsync($"/usuarios/{usuario.CorreoElectronico}/contrasena", new { NuevaContrasena = nuevaContrasena });
                response.EnsureSuccessStatusCode();
                Assert.That(response.IsSuccessStatusCode, Is.True);
                BorrarUsuario(usuario.CorreoElectronico); }
            catch (Exception ex) {
                Assert.Fail($"Excepción al actualizar contraseña de usuario: {ex.Message}");
            }
        }
        [Test]
        public async Task ActualizarRolesUsuario()
        {
            try
            {
                Usuario usuario = new Usuario("prueba@correo.com", "Fausto", "contraseña123");
                await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
                List<string> roles = new List<string>();
                var response = await this.mySession.GetClient().PutAsJsonAsync($"/usuarios/{usuario.CorreoElectronico}/roles", roles);
                response.EnsureSuccessStatusCode();
                Assert.That(response.IsSuccessStatusCode, Is.True);
                BorrarUsuario(usuario.CorreoElectronico);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al actualizar roles de usuario: {ex.Message}");
            }
        }
        [Test]
        public async Task EliminarUsuario()
        {
            try{Usuario usuario = new Usuario("pruebafaustoo12345678765432123456787654321@correo.com", "Fausto", "contraseña123");
            await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
            var response = await this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{usuario.CorreoElectronico}");
            Assert.That(response.IsSuccessStatusCode, Is.True);}
            catch (Exception ex){
                Assert.Fail($"Excepción al eliminar usuario: {ex.Message}");
            }
        }
    }
}
