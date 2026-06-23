using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.Client;
using SesionMT.LogConfig;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace Articulos_Frontend.Client;

public class RolApiClient: BaseApiClient
{
    TokenHelper tokenHelper = new TokenHelper();
    private EnsureFunctions ensureFunctions = new EnsureFunctions();
    public RolApiClient(UserSession session): base(session){
    }
    public async Task InitAsync(string currentServer)
    {
        /*this.mySession = new UserSession(currentServer, mySession.CargarToken());
        mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");*/
    }
    public async Task<List<Rol>> ObtenerNombreRoles()
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync("/roles/nombres");
            ensureFunctions.ensureGet(response);
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
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync("/roles");
            ensureFunctions.ensureGet(response);
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
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync($"/roles/{id}");
            ensureFunctions.ensureGet(response);
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
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync($"/roles/nombre/{nombre}");
            ensureFunctions.ensureGet(response);
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
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PostAsJsonAsync("/roles", rol);
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task ActualizarRol(Rol rol) {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/roles/{rol.Id}", rol);
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task EliminarRol(int id) {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().DeleteAsync($"/roles/{id}");
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task checkTokenExpiration()
    {
        if (tokenHelper.checkRenovateToken(this.mySession.getToken().exp))
        {
            await mySession.GenerateToken();
        }
    }
}
