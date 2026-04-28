using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Articulos_Frontend.Client
{
    internal class ConfiguracionApiClient
    {
        private readonly HttpClient httpClient;
        public ConfiguracionApiClient()
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
        public async Task<ConfiguracionModel> ObtenerConfiguracionPorCorreo(string correo)
        {
            try
            {
                var response = await httpClient.GetAsync($"/configuracion/{correo}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                return await httpClient.GetFromJsonAsync<ConfiguracionModel>($"/configuracion/{correo}");
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception($"Error al conectar con el servidor API: {ex.Message}");
            }
        }
        public async Task<ConfiguracionModel> GuardarConfiguracionPorCorreo(string correo, ConfiguracionModel configuracion)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync($"/guardar_configuracion/{correo}", configuracion);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ConfiguracionModel>();
            }
            catch (Exception ex)
            {
                Log.Error("No se pudo conectar al servidor API.");
                throw new Exception($"Error al conectar con el servidor API: {ex.Message}");
            }
        }
    }
}
