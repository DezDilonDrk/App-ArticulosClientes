using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;


namespace Articulos_Frontend.Client
{
    internal class PedidoApiClient
    {
        private readonly HttpClient httpClient;
        public PedidoApiClient()
        {
            try
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://PT-0057:5000");
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task<List<Pedido>> ObtenerClientes()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Pedido>>("/clientes");
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task<List<Pedido>> BuscarPorIdPedido(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Pedido>>($"/pedidos/?id_pedido={id}");
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task<Pedido?> ObtenerPorDniCliente(string dni)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Pedido>($"/pedidos/cliente{dni}");
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task Crear(Pedido pedido)
        {
            try
            {
                await httpClient.PostAsJsonAsync("/pedidos", pedido);
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task<bool> Actualizar(string dni, Pedido pedido)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"/pedidos/{dni}", pedido);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task Eliminar(int id)
        {
            try
            {
                await httpClient.DeleteAsync($"/pedidos/{id}");
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
    }
}
