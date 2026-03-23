using System.Net.Http;
using System.Net.Http.Json;
using MTCore_AC.Entidades;

public class ArticuloApiClient
{
    private readonly HttpClient httpClient;

    public ArticuloApiClient()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://192.168.1.157:5000");
    }   

    public async Task<List<Articulo>> ObtenerArticulos()
    {
        var response = await httpClient.GetAsync("/articulos");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error API: {response.StatusCode}");
        }

        return await response.Content.ReadFromJsonAsync<List<Articulo>>() ?? new List<Articulo>();
    }

    public async Task<Articulo?> ObtenerPorId(int id)
    {
        var response = await httpClient.GetAsync($"/articulos/{id}");

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Articulo>();
    }
    public async Task Crear(Articulo articulo)
    {
        var response = await httpClient.PostAsJsonAsync("/articulos", articulo);
        response.EnsureSuccessStatusCode();
    }

    public async Task Actualizar(int id, Articulo articulo)
    {
        var response = await httpClient.PutAsJsonAsync($"/articulos/{id}", articulo);
        response.EnsureSuccessStatusCode();
    }

    public async Task Eliminar(int id)
    {
        var response = await httpClient.DeleteAsync($"/articulos/{id}");
        response.EnsureSuccessStatusCode();
    }
}