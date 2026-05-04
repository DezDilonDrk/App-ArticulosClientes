using System;
using System.Collections.Generic;
using System.Text;
using Articulos_Frontend.LogConfig;
using MTCore_AC.Entidades;
using System.Net.Http;
using System.Net.Http.Json;

namespace Articulos_Frontend.Client;

public class RolApiClient
{
    private readonly HttpClient httpClient;

    public RolApiClient()
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

    public async Task<List<Rol>> ObtenerNombreRoles()
    {
        try
        {
            var response = await httpClient.GetAsync("/roles/nombres");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener nombres de roles: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<Rol>>() ?? new List<Rol>();
        }
        catch
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw new Exception("Error al conectar con el servidor API.");
        }
    }

    public async Task<List<Rol>> ObtenerRoles()
    {
        try
        {
            var response = await httpClient.GetAsync("/roles");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener roles: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<Rol>>() ?? new List<Rol>();
        }
        catch (HttpRequestException ex)
        {
            Log.Error("No se pudo conectar al servidor API.", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error("Error inesperado al obtener roles.", ex);
            throw;
        }
    }

    public async Task<Rol> ObtenerPorId(int id)
    {
        try
        {
            var response = await httpClient.GetAsync($"/roles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener rol por ID: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Rol>();
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API para obtener rol por ID: {id}.", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error inesperado al obtener rol por ID: {id}.", ex);
            throw;
        }
    }

    public async Task<Rol> ObtenerPorNombre(string nombre)
    {
        try
        {
            var response = await httpClient.GetAsync($"/roles/nombre/{nombre}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener rol por nombre: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Rol>();
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API para obtener rol por nombre: {nombre}.", ex);
            throw;

        }
        catch (Exception ex)
        {
            Log.Error($"Error inesperado al obtener rol por nombre: {nombre}.", ex);
            throw;
        }
    }

    public async Task CrearRol(Rol rol)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("/roles", rol);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al crear rol: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch(HttpRequestException ex) { 
            Log.Error("No se pudo conectar al servidor API.", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error("Error inesperado al crear rol.", ex);
            throw;
        }
    }

    public async Task ActualizarRol(Rol rol)
    {
        try
        {
            var response = await httpClient.PutAsJsonAsync($"/roles/{rol.Id}", rol);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al actualizar rol: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API para actualizar rol con ID: {rol.Id}.", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error inesperado al actualizar rol con ID: {rol.Id}.", ex);
            throw;
        }
    }
    public async Task EliminarRol(int id)
        {
        try
        {
            var response = await httpClient.DeleteAsync($"/roles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al eliminar rol: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API para eliminar rol con ID: {id}.", ex);
            throw;

        }
        catch (Exception ex)
        {
            Log.Error($"Error inesperado al eliminar rol con ID: {id}.", ex);
            throw;
        }
    }
}
