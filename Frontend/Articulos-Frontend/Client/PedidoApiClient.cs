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
        public async Task<Pedido> BuscarPorIdPedido(string id)
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
                var response = await httpClient.PostAsJsonAsync("/pedidos", pedido);
                string contenido = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode){
                    MessageBox.Show($"Error al crear el pedido: {contenido}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Error al crear el pedido en el servidor API.");
                }
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task<bool> Actualizar(string id, Pedido pedido)
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
        public async Task Eliminar(string id)
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
        public async Task AgregarArticulos(List<PedidoArticulos> articulos)
        {
            try
            {
                for (int i = 0; i < articulos.ToArray().Length; i ++ ) 
                { 
                    PedidoArticulos articulo = articulos[i];
                    await httpClient.PostAsJsonAsync("/pedidos/articulo", articulo); }
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
    }
}
