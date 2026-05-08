using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace TestProjectMT
{
    public class UsuarioRolTest : BaseTest
    {
		string currentServer = "";
		[OneTimeSetUp]
		public async Task Setup()
        {
            await this.Init(UrlMT.serverLocal);
		}
        [Test]
        public async Task ObtenerTodo()
        {
            try { var response = await this.mySession.GetClient().GetAsync($"/usuario-roles");
                Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío"); }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener roles de usuario: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerRolesPorEmail()
        {
            try{
            Usuario usuario = new Usuario("prueba@correo.com", "Fausto", "contraseña123");
            this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{usuario.CorreoElectronico}");
            var userResp = await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
            Assert.That(userResp.IsSuccessStatusCode, Is.True);
            var obtenerRoles = await this.mySession.GetClient().GetAsync($"/roles");
            Assert.That(obtenerRoles.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
            var roles = await obtenerRoles.Content.ReadFromJsonAsync<List<Rol>>();
            Assert.That(roles, Is.Not.Null.And.Not.Empty, "No se obtuvieron roles para el test");
            Rol rol = roles[2];
            var response = await this.mySession.GetClient().GetAsync($"/usuario-roles/usuario/{usuario.CorreoElectronico}");
            Assert.That(response.IsSuccessStatusCode, Is.True);
            var body = await response.Content.ReadAsStringAsync();
            Assert.That(body, Is.Not.Empty);}
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener rol por email: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerPorRol()
        {
            try
            {
                var obtenerRoles = await this.mySession.GetClient().GetAsync($"/roles");
                Assert.That(obtenerRoles.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");

                var roles = await obtenerRoles.Content.ReadFromJsonAsync<List<Rol>>();
                Assert.That(roles, Is.Not.Null.And.Not.Empty, "No se obtuvieron roles para el test");

                var rol = roles[2];

                Usuario usuario = new Usuario("prueba@correo.com", "Fausto", "contraseña123");
                this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{usuario.CorreoElectronico}"); //Esto es por si este usuario estaba en la base de datos ya, aunque procuro borrarlo luego
                var userResp = await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);
                Assert.That(userResp.IsSuccessStatusCode, Is.True);

                var asignarResp = await this.mySession.GetClient().PutAsJsonAsync(
                    $"/usuarios/{usuario.CorreoElectronico}/roles",
                    new List<string> { rol.Nombre }
                );
                Assert.That(asignarResp.IsSuccessStatusCode, Is.True);

                var response = await this.mySession.GetClient().GetAsync($"/usuario-roles/rol/{rol.Id}");
                Assert.That(response.IsSuccessStatusCode, Is.True);

                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty);

                await this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{usuario.CorreoElectronico}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener rol por ID: {ex.Message}");
            }
        }
        [Test]
        public async Task EliminarRoldeUsuario()
        {
            try
            {
                var obtenerRoles = await this.mySession.GetClient().GetAsync($"/roles");
                Assert.That(obtenerRoles.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");

                var roles = await obtenerRoles.Content.ReadFromJsonAsync<List<Rol>>();
                Assert.That(roles, Is.Not.Null.And.Not.Empty, "No se obtuvieron roles para el test");

                var rol = roles[2];

                Usuario usuario = new Usuario("prueba@correo.com", "Fausto", "contraseña123");
                var userResp = await this.mySession.GetClient().PostAsJsonAsync($"/usuarios", usuario);

                var asignarResp = await this.mySession.GetClient().PutAsJsonAsync(
                    $"/usuarios/{usuario.CorreoElectronico}/roles",
                    new List<string> { rol.Nombre }
                );
                Assert.That(asignarResp.IsSuccessStatusCode, Is.True);
                var response = await this.mySession.GetClient().DeleteAsync($"/usuario-roles/{rol.Id}/{usuario.CorreoElectronico}");
                Assert.That(response.IsSuccessStatusCode, Is.True);
                this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{usuario.CorreoElectronico}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al eliminar rol de usuario: {ex.Message}");
            }
        }
    }
}
