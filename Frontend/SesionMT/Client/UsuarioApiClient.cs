using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System.Net.Http.Json;
using System.Text.Json;
using static MTCore_AC.DTO.LoginDtos;

namespace Articulos_Frontend.Client;

public class UsuarioApiClient
{
    private UserSession mySession;
    public UsuarioApiClient(UserSession session) {
        this.mySession = session;
    }
    public UsuarioApiClient(){}
    public async Task InitAsync(string currentServer)
    {
        //this.mySession = new UserSession(currentServer);
        mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");
    }
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var response = await this.mySession.GetClient().PostAsJsonAsync("usuarios/login", request);

        if (!response.IsSuccessStatusCode)
            return null;

        var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
        return loginResponse;
    }

    public async Task<List<Usuario>> ObtenerUsuarios()
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync("/usuarios");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener usuarios: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<List<Usuario>>() ?? new List<Usuario>();
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }
        catch (NotSupportedException ex)
        {
            Log.Error($"Error de formato: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error($"Error deserializando JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error inesperado: {ex.Message}");
            throw;
        }
    }

    public async Task<List<string>> ObtenerRolesUsuario(string correo)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/usuarios/{correo}/roles");

            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener los roles del usuario: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<string>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }
        catch (NotSupportedException ex)
        {
            Log.Error("Error de formato: " + ex.Message);
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error("Error deserializando JSON: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Log.Error("Error inesperado: " + ex.Message);
            throw;
        }
    }

    public async Task<Usuario> ObtenerPorCorreo(string Correo)
    {
        try
        {
            var response = await this.mySession.GetClient().GetAsync($"/usuarios/{Correo}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al obtener usuario por correo: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
            return await response.Content.ReadFromJsonAsync<Usuario>() ?? new Usuario();
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }
        catch (NotSupportedException ex)
        {
            Log.Error($"Error de formato: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error($"Error deserializando JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error inesperado: {ex.Message}");
            throw;
        }
    }

    public async Task CrearUsuario(Usuario usuario)
    {
        try
        {
            var response = await this.mySession.GetClient().PostAsJsonAsync("/usuarios", usuario);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al crear usuario: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }catch (NotSupportedException ex)
        {
            Log.Error($"Error de formato: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error($"Error serializando JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error al crear usuario: {ex.Message}");
            throw;
        }
    }
    public async Task EliminarUsuario(string correo)
    {
        try
        {
            var response = await this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{correo}");
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al eliminar usuario: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }catch (NotSupportedException ex)
        {
            Log.Error($"Error de formato: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error($"Error serializando JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error al eliminar usuario: {ex.Message}");
            throw;
        }
    }
    public async Task ActualizarUsuario(Usuario usuario)
    {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/usuarios", usuario);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al actualizar usuario: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }catch (NotSupportedException ex)
        {
            Log.Error($"Error de formato: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error($"Error serializando JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error al actualizar usuario: {ex.Message}");
            throw;
        }
    }

    public async Task ActualizarContrasena(string correo, string nuevaContrasena)
    {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync(
            $"/usuarios/{correo}/contrasena",
            new { NuevaContrasena = nuevaContrasena }
        );

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error API: {response.StatusCode} - {error}");
            }
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }catch (NotSupportedException ex)
        {
            Log.Error($"Error de formato: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error($"Error serializando JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error al actualizar contraseña: {ex.Message}");
            throw;

        }
    }

    public async Task ActualizarRolesUsuario(string correo, List<string> roles)
    {
        try
        {
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/usuarios/{correo}/roles", roles);
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error al actualizar roles del usuario: {response.StatusCode}");
                throw new Exception($"Error API: {response.StatusCode}");
            }
        }
        catch(HttpRequestException ex)
        {
            Log.Error($"Error HTTP: {ex.Message}");
            throw;
        }catch (NotSupportedException ex)
        {
            Log.Error($"Error de formato: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Log.Error($"Error serializando JSON: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Log.Error($"Error al actualizar roles del usuario: {ex.Message}");
            throw;
        }
    }
}
