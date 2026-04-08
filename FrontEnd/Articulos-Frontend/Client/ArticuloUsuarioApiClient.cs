using System;
using System.Collections.Generic;
using System.Text;
using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System.Net.Http.Json;

namespace Articulos_Frontend.Client;

public class ArticuloUsuarioApiClient
{
    private readonly HttpClient httpClient;

    public ArticuloUsuarioApiClient()
    {
        try
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://PT-0041:5000");
        }
        catch
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw new Exception("Error al conectar con el servidor API.");
        }
    }

    public async Task<List<ArticuloUsuario>> ObtenerArticuloUsuario()
    {
        try
        {
            var response = await httpClient.GetAsync("/articulos-usuarios");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener usuarios: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<ArticuloUsuario>>() ?? new List<ArticuloUsuario>();
        }
        catch
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw new Exception("Error al conectar con el servidor API.");
        }
    }

    public async Task Crear(ArticuloUsuario au)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("/articulos-usuarios", au);
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw new Exception("Error al conectar con el servidor API.");
        }
    
    }

    public async Task EliminarArticuloUsuario(int id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"/articulos-usuarios/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al eliminar artículo-usuario: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw new Exception("Error al conectar con el servidor API.");
        }
    }
}
