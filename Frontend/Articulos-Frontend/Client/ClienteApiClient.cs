using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Articulos_Frontend.LogConfig;
using System.Net.Sockets;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Articulos_Frontend.Client
{
    internal class ClienteApiClient
    {
        private readonly HttpClient httpClient;
        public ClienteApiClient()
        {
            try
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://PT-0057:5000");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AppState.Token);
            }
            catch
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception("Error al conectar con el servidor API.");
            }
        }
        public async Task<List<Cliente>> ObtenerClientes()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Cliente>>("/clientes");
            }catch (HttpRequestException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }catch (SocketException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Socket error: " + ex.Message);
                throw;
            }catch(WebException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Web error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw;
            }
        }
        public async Task<List<Cliente>> BuscarPorNombre(string nombre)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Cliente>>($"/clientes?nombre={nombre}");
            }
            catch (HttpRequestException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
            catch (SocketException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Socket error: " + ex.Message);
                throw;
            }
            catch (WebException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Web error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task<Cliente?> ObtenerPorDni(string dni)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Cliente>($"/clientes/{dni}");
            }catch (HttpRequestException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
            catch (SocketException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Socket error: " + ex.Message);
                throw;
            }
            catch (WebException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Web error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task Crear(Cliente cliente)
        {
            try
            {
                await httpClient.PostAsJsonAsync("/clientes", cliente);
            }catch (HttpRequestException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
            catch (SocketException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Socket error: " + ex.Message);
                throw;
            }
            catch (WebException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Web error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
        }
        public async Task<bool> Actualizar(string dni, Cliente cliente)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync($"/clientes/{dni}", cliente);
                return response.IsSuccessStatusCode;
            }catch (HttpRequestException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
            catch (SocketException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Socket error: " + ex.Message);
                throw;
            }
            catch (WebException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Web error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw;
            }
        }
        public async Task Eliminar(string dni)
        {
            try
            {
                await httpClient.DeleteAsync($"/clientes/{dni}");
            }catch (HttpRequestException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }
            catch (SocketException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Socket error: " + ex.Message);
                throw;
            }
            catch (WebException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Web error: " + ex.Message);
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
