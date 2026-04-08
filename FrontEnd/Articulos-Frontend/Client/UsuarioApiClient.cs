using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System.Net.Http.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend.Client;

public class UsuarioApiClient
{
    private readonly HttpClient httpClient;

    public UsuarioApiClient()
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

    public async Task<List<Usuario>> ObtenerUsuarios()
    {
        try
        {
            var response = await httpClient.GetAsync("/usuarios");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener usuarios: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<Usuario>>() ?? new List<Usuario>();
        }
        catch
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw new Exception("Error al conectar con el servidor API.");
        }
    }

    public async Task<Usuario> ObtenerPorCorreo(string Correo)
    {
        try
        {
            var response = await httpClient.GetAsync($"/usuarios/{Correo}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener usuario por correo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Usuario>() ?? new Usuario();
        }
        catch
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw new Exception("Error al conectar con el servidor API.");
        }
    }
}
