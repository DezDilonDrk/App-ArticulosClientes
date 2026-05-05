using Articulos_Frontend;
using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;

public class ArticuloApiClient
{
    private readonly HttpClient httpClient;

    public ArticuloApiClient()
    {
        try {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(AppState.getServer());
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AppState.Token);
        } catch { 
            Log.Error("No se pudo conectar al servidor API.");
             throw new Exception("Error al conectar con el servidor API.");
        }
    }
    public async Task<List<Articulo>> ObtenerArticulos()
    {
        try {
            

            var response = await httpClient.GetAsync("/articulos");

            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículos: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<List<Articulo>>() ?? new List<Articulo>();
        } catch(Exception ex) 
        {
            Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message, ex);
            throw;
        }
    }
    public async Task<Articulo?> ObtenerPorId(string id)
    {
        try
        {
            var response = await httpClient.GetAsync($"/articulos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículos: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<Articulo>();
        }
        catch(Exception ex)
        {
            Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message, ex);
            throw;
        }
    }
    public async Task<Articulo?> Crear(Articulo articulo)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("/articulos", articulo);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículos: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Articulo>();
        }
        catch(Exception ex)
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw;
        }
    }

    public async Task Actualizar(string id, Articulo articulo)
    {
        try
        {
            var response = await httpClient.PutAsJsonAsync($"/articulos/{id}", articulo);
            response.EnsureSuccessStatusCode();

        }
        catch(Exception ex)
        {
            Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message, ex);
            throw;
        }
    }

    public async Task Eliminar(string id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"/articulos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículos: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message, ex);
            throw;
        }
    }
}