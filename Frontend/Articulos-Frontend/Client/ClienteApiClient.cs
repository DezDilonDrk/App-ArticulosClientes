using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Articulos_Frontend.Client
{
    public class ClienteApiClient
    {
        UserSession mySession;
        public ClienteApiClient(){}
        public async Task InitAsync(string currentServer)
        {
            this.mySession = new UserSession(currentServer);
            await mySession.Init("emilio.martinez@mthelmets.com", "emilio123");
        }
        public async Task<List<Cliente>> ObtenerClientes()
        {
            try
            {
                return await this.mySession.GetClient().GetFromJsonAsync<List<Cliente>>("/clientes");
            }catch(HttpRequestException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message);
                throw;
            }catch(SocketException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Socket error: " + ex.Message);
                throw;
            }catch(WebException ex)
            {
                Log.Error("No se pudo conectar al servidor API. Web error: " + ex.Message);
                throw;
            }
            catch(Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw;
            }
        }
        public async Task<List<Cliente>> BuscarPorNombre(string nombre)
        {
            try
            {
                return await this.mySession.GetClient().GetFromJsonAsync<List<Cliente>>($"/clientes?nombre={nombre}");
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
                return await this.mySession.GetClient().GetFromJsonAsync<Cliente>($"/clientes/{dni}");
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
                await this.mySession.GetClient().PostAsJsonAsync("/clientes", cliente);
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
                var response = await this.mySession.GetClient().PutAsJsonAsync($"/clientes/{dni}", cliente);
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
                await this.mySession.GetClient().DeleteAsync($"/clientes/{dni}");
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
