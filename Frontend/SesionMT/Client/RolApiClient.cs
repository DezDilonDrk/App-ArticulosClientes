using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
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
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<Rol>>() ?? new List<Rol>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<List<Rol>> ObtenerRoles()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync("/roles");
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<Rol>>() ?? new List<Rol>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }

    public async Task<Rol> ObtenerPorId(int id)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/roles/{id}");
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<Rol>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }

    public async Task<Rol> ObtenerPorNombre(string nombre)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/roles/nombre/{nombre}");
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<Rol>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }

    public async Task CrearRol(Rol rol)
    {
        try
        {
            var response = await this.mySession.GetClient().PostAsJsonAsync("/roles", rol);
            ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task ActualizarRol(Rol rol) {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/roles/{rol.Id}", rol);
            ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task EliminarRol(int id) {
        try
        {
            var response = await this.mySession.GetClient().DeleteAsync($"/roles/{id}");
            ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    private void ensureGet(HttpResponseMessage response, [CallerMemberName] string methodName = "")
    {
        if (!response.IsSuccessStatusCode)
        {
            Log.Error($"Error en {methodName}: {response.Content}");
            throw new Exception($"Error con {methodName}: {response.StatusCode}");
        }
    }
}
