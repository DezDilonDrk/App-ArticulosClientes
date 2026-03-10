using System.Net.Http;
using System.Net.Http.Json;
using Articulos_Backend.Articulos;

public class ArticuloApiClient
{
    private readonly HttpClient _http;

    public ArticuloApiClient()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("http://192.168.1.148:5000");
    }   

    public async Task<List<Articulo>> ObtenerArticulos()
    {
        return await _http.GetFromJsonAsync<List<Articulo>>("/articulos");
    }

    public async Task<Articulo?> ObtenerPorId(int id)
    {
        return await _http.GetFromJsonAsync<Articulo>($"/articulos/{id}");
    }
    public async Task Crear(Articulo articulo)
    {
        await _http.PostAsJsonAsync("/articulos", articulo);
    }

    public async Task<bool> Actualizar(int id, Articulo articulo)
{
    var response = await _http.PutAsJsonAsync($"/articulos/{id}", articulo);
    return response.IsSuccessStatusCode;
}

    public async Task Eliminar(int id)
    {
        await _http.DeleteAsync($"/articulos/{id}");
    }
}