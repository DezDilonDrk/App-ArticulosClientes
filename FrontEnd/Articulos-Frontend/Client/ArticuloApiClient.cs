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
            httpClient.BaseAddress = new Uri("http://PT-0057:5000");
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
        } catch(HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }catch(TaskCanceledException ex)
        {
            Log.Error($"Tiempo de espera agotado al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch (WebException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch (SocketException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error inesperado al obtener artículos. Error: {ex.Message}", ex);
            throw;
        }
    }
    public async Task<Articulo?> ObtenerPorId(int id)
    {
        try
        {
            var response = await httpClient.GetAsync($"/articulos/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener artículo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<Articulo>();
        }catch(HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(TaskCanceledException ex)
        {
            Log.Error($"Tiempo de espera agotado al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(WebException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(SocketException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch (Exception ex)
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
                Log.Error($"Error al crear artículo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Articulo>();
        }catch(HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(TaskCanceledException ex)
        {
            Log.Error($"Tiempo de espera agotado al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(WebException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(SocketException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error("No se pudo conectar al servidor API.");
            throw;
        }
    }

    public async Task Actualizar(int id, Articulo articulo)
    {
        try
        {
            var response = await httpClient.PutAsJsonAsync($"/articulos/{id}", articulo);
            response.EnsureSuccessStatusCode();

        }catch(HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(TaskCanceledException ex)
        {
            Log.Error($"Tiempo de espera agotado al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(WebException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(SocketException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message, ex);
            throw;
        }
    }

    public async Task Eliminar(int id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"/articulos/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al eliminar artículo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }catch(HttpRequestException ex)
        {
            Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(TaskCanceledException ex)
        {
            Log.Error($"Tiempo de espera agotado al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(WebException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch(SocketException ex)
        {
            Log.Error($"Error de red al conectar con el servidor API. Error: {ex.Message}", ex);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error("No se pudo conectar al servidor API. Error: " + ex.Message, ex);
            throw;
        }
    }
}