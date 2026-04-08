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
        public async Task<List<Pedido>> ObtenerPedidos()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Pedido>>("/pedidos");
            }
            catch (Exception ex)
            {
                Log.Error($"No se pudo conectar al servidor API: {ex.Message}");
                throw new Exception($"Error al conectar con el servidor API: {ex.Message}");
            }
        }
        public async Task<Pedido> BuscarPorIdPedido(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Pedido>($"/pedidos/{id}");
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
                return await httpClient.GetFromJsonAsync<Pedido>($"/pedidos/cliente?dni={dni}");
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
        public async Task<bool> Actualizar(int id, Pedido pedido)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"/pedidos/{id}", pedido);
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
