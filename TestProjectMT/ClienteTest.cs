using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using MTCore_AC.Entidades;
using SesionMT;

namespace TestProjectMT
{
    public class ClienteTest : BaseTest
    {
		string currentServer = "";
		[OneTimeSetUp]
		public async Task Setup()
        {
           await this.Init(UrlMT.serverLocal);
		}
        private async void BorrarCliente(string dni)
        {
            this.mySession.GetClient().DeleteAsync($"/clientes/{dni}");
        }
        [Test]
        public async Task ObtenerClientes()
        {
            try { var response = await this.mySession.GetClient().GetAsync($"/clientes");
                Assert.That(response.IsSuccessStatusCode, Is.True, "El endpoint no devolvió 200");
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty, "El cuerpo está vacío");
                Assert.That(body.Contains("id"), Is.True, "El JSON no contiene ningún Id de clientes");
            } catch (Exception ex) {
                Assert.Fail($"Excepción al obtener clientes: {ex.Message}");
            }
        }
        [Test]
        public async Task BuscarClientePorNombre() {
            try { var response = await this.mySession.GetClient().GetAsync($"/clientes?Nombre=Federico");
                Assert.That(response.IsSuccessStatusCode, Is.True);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Empty);
            } catch (Exception ex) {
                Assert.Fail($"Excepción al buscar cliente por nombre: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearCliente()
        {
            try { Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
                var response = await this.mySession.GetClient().PostAsJsonAsync($"/clientes", cliente);
                Assert.That(response.IsSuccessStatusCode, Is.True);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty);
                BorrarCliente(cliente.Dni);
            } catch (Exception ex) {
                Assert.Fail($"Excepción al crear cliente: {ex.Message}");
            }
        }
        [Test]
        public async Task CrearMismoCliente()
        {
            try
            {
                Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
                await this.mySession.GetClient().PostAsJsonAsync($"/clientes", cliente);
                var response = await this.mySession.GetClient().PostAsJsonAsync($"/clientes", cliente);
                Assert.That(response.IsSuccessStatusCode, Is.False);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body, Is.Not.Null.And.Not.Empty);
                Assert.That(response.IsSuccessStatusCode, Is.False);
                BorrarCliente(cliente.Dni);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al crear el mismo cliente: {ex.Message}");
            }
        }
        [Test]
        public async Task ObtenerClientePorDni()
        {
            try
            {
                var response = await this.mySession.GetClient().GetAsync($"/clientes/12345678Z");
                Assert.That(response.IsSuccessStatusCode, Is.True);
                var body = await response.Content.ReadAsStringAsync();
                Assert.That(body.Contains("id"), Is.True);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al obtener cliente por DNI: {ex.Message}");
            }
        }
        [Test]
        public async Task ActualizarCliente()
        {
            try
            {
                Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
                await this.mySession.GetClient().PostAsJsonAsync($"/clientes", cliente);
                var response = await this.mySession.GetClient().PutAsJsonAsync($"/clientes/{cliente.Dni}", cliente);
                response.EnsureSuccessStatusCode();
                Assert.That(response.IsSuccessStatusCode, Is.True);
                BorrarCliente(cliente.Dni);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al actualizar cliente: {ex.Message}");
            }
        }

        [Test]
        public async Task EliminarCliente()
        {
            try
            {
                Cliente cliente = new Cliente("12345678A", "Fausto", "De Pruebas", "faustoeldepruebas@gmail.com", DateTime.Now, null);
                await this.mySession.GetClient().PostAsJsonAsync($"/clientes", cliente);
                var response = await this.mySession.GetClient().DeleteAsync($"/clientes/12345678A");
                Assert.That(response.IsSuccessStatusCode, Is.True);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Excepción al eliminar cliente: {ex.Message}");
            }
        }
    }
}
