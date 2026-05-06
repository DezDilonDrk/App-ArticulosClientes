using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;
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
                httpClient.BaseAddress = new Uri(AppState.getServer());
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AppState.Token);
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task<List<Pedido>> ObtenerPedidos()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Pedido>>("/pedidos");
            }catch (HttpRequestException ex)
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }catch (JsonException ex)
            {
                Log.Error($"Error al deserializar la respuesta del servidor API: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error($"No se pudo conectar al servidor API: {ex.Message}");
                throw;
            }
        }
        public async Task<Pedido> BuscarPorIdPedido(string id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Pedido>($"/pedidos/{id}");
            }catch (HttpRequestException ex)
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Log.Error($"Error al deserializar la respuesta del servidor API: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error($"No se pudo conectar al servidor API: {ex.Message}");
                throw;
            }
        }
        public async Task<Pedido?> ObtenerPorDniCliente(string dni)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Pedido>($"/pedidos/cliente?dni={dni}");
            }catch(HttpRequestException ex) 
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }
             catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Log.Error($"Error al deserializar la respuesta del servidor API: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task Crear(Pedido pedido)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("/pedidos", pedido);
                string contenido = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Error al crear el pedido: {contenido}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Error al crear el pedido en el servidor API.");
                }
            }catch (HttpRequestException ex)
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task<bool> Actualizar(string id, Pedido pedido)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"/pedidos/{id}", pedido);
                return response.IsSuccessStatusCode;
            }catch (HttpRequestException ex)
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task Eliminar(string id)
        {
            try
            {
                await httpClient.DeleteAsync($"/pedidos/{id}");
            }catch (HttpRequestException ex)
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task AgregarArticulos(List<PedidoArticulos> articulos)
        {
            try
            {
                for (int i = 0; i < articulos.ToArray().Length; i++)
                {
                    PedidoArticulos articulo = articulos[i];
                    await httpClient.PostAsJsonAsync("/pedidos/articulo", articulo);
                }
            }catch (HttpRequestException ex)
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error($"No se pudo conectar al servidor API: {ex.Message}");
                throw;
            }
        }
        public async Task<List<PedidoArticulos>> ObtenerArticulosDePedido(string idPedido)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<PedidoArticulos>>($"/pedidos/{idPedido}/articulos");
            }catch (HttpRequestException ex)
            {
                Log.Error($"Error al conectar con el servidor API: {ex.Message}");
                throw;
            }
            catch (TaskCanceledException ex)
            {
                Log.Error($"La solicitud al servidor API se agotó: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Log.Error($"Error al deserializar la respuesta del servidor API: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
    }
}
