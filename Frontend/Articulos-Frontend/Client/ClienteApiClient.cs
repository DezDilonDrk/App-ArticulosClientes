using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using ClientesASPNET;

using static System.Net.WebRequestMethods;

namespace Articulos_Frontend.Client
{
    internal class ClienteApiClient
    {
        private readonly HttpClient httpClient;
        public ClienteApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://192.168.1.147:5000");
        }
        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await httpClient.GetFromJsonAsync<List<Cliente>>("/clientes");
        }
        public async Task<List<Cliente>> BuscarPorNombre(string nombre)
        {
            return await httpClient.GetFromJsonAsync<List<Cliente>>($"/clientes?nombre={nombre}");
        }
        public async Task<Cliente?> ObtenerPorDni(string dni)
        {
            return await httpClient.GetFromJsonAsync<Cliente>($"/clientes/{dni}");
        }
        public async Task Crear(Cliente cliente)
        {
            await httpClient.PostAsJsonAsync("/clientes", cliente);
        }
        public async Task<bool> Actualizar(string dni, Cliente cliente)
        {
            var response = await httpClient.PutAsJsonAsync($"/clientes/{dni}", cliente);
            return response.IsSuccessStatusCode;
        }
        public async Task Eliminar(string dni)
        {
            await httpClient.DeleteAsync($"/clientes/{dni}");
        }
    }
}
