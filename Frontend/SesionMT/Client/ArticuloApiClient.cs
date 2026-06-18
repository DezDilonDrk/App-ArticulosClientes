using Articulos_Frontend;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.Client;
using SesionMT.LogConfig;
using SesionMT.LogConfig;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using static System.Collections.Specialized.BitVector32;

public class ArticuloApiClient: BaseApiClient
{
    private TokenHelper tokenHelper = new TokenHelper();
    private EnsureFunctions ensureFunctions = new EnsureFunctions();
    public ArticuloApiClient(UserSession session): base(session)
    {
    }
    public async Task<List<ArticuloDTO>> ObtenerArticulos()
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().GetAsync("/articulos");
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<ArticuloDTO>>() ?? new List<ArticuloDTO>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<Articulo?> ObtenerPorId(string id)
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().GetAsync($"/articulos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<Articulo>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }

    public async Task<List<ArticuloDTO>> ObtenerArticuloDTO()
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().GetAsync($"/articulos/dto");
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<ArticuloDTO>>() ?? new List<ArticuloDTO>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }

    public async Task<List<DisenoCasco>> ObtenerDisenosCascos()
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().GetAsync("/disenos-cascos");
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<DisenoCasco>>() ?? new List<DisenoCasco>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<DisenoCasco> ObtenerDisenoPorId(string id)
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().GetAsync($"/disenos-cascos/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<DisenoCasco>();

        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<string> ObtenerIdDiseno(string nombre)
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().GetAsync($"/disenos-cascos/nombre/{nombre}");
            ensureFunctions.ensureGet(response);
            var diseno = await response.Content.ReadFromJsonAsync<string>();
            return diseno;
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<Articulo?> Crear(Articulo articulo)
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().PostAsJsonAsync("/articulos", articulo);
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<Articulo>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task Actualizar(string id, Articulo articulo)
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().PutAsJsonAsync($"/articulos/{id}", articulo);
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task Eliminar(string id)
    {
        try {
            await checkTokenExpiration();
            var response = await mySession.GetClient().DeleteAsync($"/articulos/{id}");
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