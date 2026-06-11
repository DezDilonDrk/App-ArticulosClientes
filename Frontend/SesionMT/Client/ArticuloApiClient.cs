using Articulos_Frontend;
using SesionMT.LogConfig;
using MTCore_AC.Entidades;
using MTCore_AC.DTO;
using SesionMT;
using SesionMT.LogConfig;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

public class ArticuloApiClient
{
    UserSession mySession;

    public ArticuloApiClient(UserSession session)
    {
        this.mySession = session;
    }
    public async Task<List<ArticuloDTO>> ObtenerArticulos()
    {
        try {
            var response = await this.mySession.GetClient().GetAsync("/articulos");
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<ArticuloDTO>>() ?? new List<ArticuloDTO>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<Articulo?> ObtenerPorId(string id)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/articulos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<Articulo>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }

    public async Task<List<ArticuloDTO>> ObtenerArticuloDTO()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/articulos/dto");
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<ArticuloDTO>>() ?? new List<ArticuloDTO>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }

    public async Task<List<DisenoCasco>> ObtenerDisenosCascos()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync("/disenos-cascos");
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<DisenoCasco>>() ?? new List<DisenoCasco>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<DisenoCasco> ObtenerDisenoPorId(string id)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/disenos-cascos/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<DisenoCasco>();

        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<string> ObtenerIdDiseno(string nombre)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/disenos-cascos/nombre/{nombre}");
            ensureGet(response);
            var diseno = await response.Content.ReadFromJsonAsync<string>();
            return diseno;
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<Articulo?> Crear(Articulo articulo)
    {
        try
        {
            var response = await this.mySession.GetClient().PostAsJsonAsync("/articulos", articulo);
            ensureGet(response);
            return await response.Content.ReadFromJsonAsync<Articulo>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task Actualizar(string id, Articulo articulo)
    {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/articulos/{id}", articulo);
            ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task Eliminar(string id)
    {
        try
        {
            var response = await this.mySession.GetClient().DeleteAsync($"/articulos/{id}");
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