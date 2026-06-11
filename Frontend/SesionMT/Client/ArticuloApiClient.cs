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
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículos: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<ArticuloDTO>>() ?? new List<ArticuloDTO>();
        } catch (Exception ex) {
            Log.Error($"Error inesperado al obtener artículos. Error: {ex.Message}", ex);
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

            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<Articulo>();
        } catch (Exception ex) {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
    }

    public async Task<List<ArticuloDTO>> ObtenerArticuloDTO()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/articulos/dto");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículos DTO: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            
            return await response.Content.ReadFromJsonAsync<List<ArticuloDTO>>() ?? new List<ArticuloDTO>();
        } catch (Exception ex) {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
    }

    public async Task<List<DisenoCasco>> ObtenerDisenosCascos()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync("/disenos-cascos");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener diseños de cascos: {response.Content}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<DisenoCasco>>() ?? new List<DisenoCasco>();
        } catch (Exception ex) {
            Log.Error($"Error: {ex.Message}", ex);
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
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener diseño de casco: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<DisenoCasco>();

        } catch (Exception ex) {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task<string> ObtenerIdDiseno(string nombre)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/disenos-cascos/nombre/{nombre}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener ID de diseño de casco: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            var diseno = await response.Content.ReadFromJsonAsync<string>();
            return diseno;
        } catch (Exception ex) {
            Log.Error($"Error al obtener ID de diseño de casco. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task<Articulo?> Crear(Articulo articulo)
    {
        try
        {
            var response = await this.mySession.GetClient().PostAsJsonAsync("/articulos", articulo);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al crear artículo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Articulo>();
        } catch (Exception ex) {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task Actualizar(string id, Articulo articulo)
    {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/articulos/{id}", articulo);
            response.EnsureSuccessStatusCode();

        } catch (Exception ex) {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task Eliminar(string id)
    {
        try
        {
            var response = await this.mySession.GetClient().DeleteAsync($"/articulos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al eliminar artículo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        } catch (Exception ex) {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
    }
}