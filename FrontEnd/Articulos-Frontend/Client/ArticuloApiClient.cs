using System.Net.Http;
using System.Net.Http.Json;
using Articulos_Backend.Articulos;

public class ArticuloApiClient
{
    private readonly HttpClient httpClient;

    public ArticuloApiClient()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://192.168.1.147:5000");
    }   

    public async Task<List<Articulo>> ObtenerArticulos()
    {
        return await httpClient.GetFromJsonAsync<List<Articulo>>("/articulos");
    }

    public async Task<Articulo?> ObtenerPorId(int id)
    {
        return await httpClient.GetFromJsonAsync<Articulo>($"/articulos/{id}");
    }
    public async Task Crear(Articulo articulo)
    {
        await httpClient.PostAsJsonAsync("/articulos", articulo);
    }

    public async Task<bool> Actualizar(int id, Articulo articulo)
{
    var response = await httpClient.PutAsJsonAsync($"/articulos/{id}", articulo);
    return response.IsSuccessStatusCode;
}

    public async Task Eliminar(int id)
    {
        await httpClient.DeleteAsync($"/articulos/{id}");
    }
}