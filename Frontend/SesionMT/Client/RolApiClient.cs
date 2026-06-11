using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Articulos_Frontend.Client;

public class RolApiClient
{
    UserSession mySession;

    public RolApiClient(UserSession session) {
        this.mySession = session;
    }
    public RolApiClient(){}
    public async Task InitAsync(string currentServer)
    {
        /*this.mySession = new UserSession(currentServer, mySession.CargarToken());
        mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");*/
    }

    public async Task<List<Rol>> ObtenerNombreRoles()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync("/roles/nombres");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener nombres de roles: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<Rol>>() ?? new List<Rol>();
        } catch (Exception ex) {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task<List<Rol>> ObtenerRoles()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync("/roles");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener roles: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<Rol>>() ?? new List<Rol>();
        } catch (Exception ex) {
            Log.Error($"Error inesperado al obtener roles. {ex.Message}", ex);
            throw;
        }
    }

    public async Task<Rol> ObtenerPorId(int id)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/roles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener rol por ID: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Rol>();
        } catch (Exception ex) {
            Log.Error($"Error inesperado al obtener rol por ID: {id}. Error: {ex.Message}", ex);
            throw;
        }
    }

    public async Task<Rol> ObtenerPorNombre(string nombre)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/roles/nombre/{nombre}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener rol por nombre: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Rol>();
        } catch (Exception ex) {
            Log.Error($"Error inesperado al obtener rol por nombre: {nombre}. Error: {ex.Message}", ex);
            throw;
        }
    }

    public async Task CrearRol(Rol rol)
    {
        try
        {
            var response = await this.mySession.GetClient().PostAsJsonAsync("/roles", rol);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al crear rol: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        } catch (Exception ex) {
            Log.Error($"Error inesperado al crear rol. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task ActualizarRol(Rol rol)
    {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/roles/{rol.Id}", rol);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al actualizar rol: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        } catch (Exception ex) {
            Log.Error($"Error inesperado al actualizar rol con ID: {rol.Id}. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task EliminarRol(int id)
        {
        try
        {
            var response = await this.mySession.GetClient().DeleteAsync($"/roles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al eliminar rol: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        } catch (Exception ex) {
            Log.Error($"Error inesperado al eliminar rol con ID: {id}. Error: {ex.Message}", ex);
            throw;
        }
    }
}
