using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.Client;
using SesionMT.LogConfig;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using static MTCore_AC.DTO.LoginDtos;

namespace Articulos_Frontend.Client;

public class UsuarioApiClient: BaseApiClient
{
    private TokenHelper tokenHelper = new TokenHelper();
    private EnsureFunctions ensureFunctions = new EnsureFunctions();
    public UsuarioApiClient(UserSession session): base(session) {
    }
    public async Task InitAsync(string currentServer)
    {
        mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");
    }
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        try {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PostAsJsonAsync("usuarios/login", request);

        if (!response.IsSuccessStatusCode)
            return null;

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return loginResponse;
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<List<Usuario>> ObtenerUsuarios()
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync("/usuarios");
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<List<Usuario>>() ?? new List<Usuario>();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<List<string>> ObtenerRolesUsuario(string correo)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync($"/usuarios/{correo}/roles");

            ensureFunctions.ensureGet(response);

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<string>>(json, optionsNotCaseSensitive);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task<Usuario> ObtenerPorCorreo(string Correo)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().GetAsync($"/usuarios/{Correo}");
            ensureFunctions.ensureGet(response);
            return await response.Content.ReadFromJsonAsync<Usuario>() ?? new Usuario();
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task CrearUsuario(Usuario usuario)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PostAsJsonAsync("/usuarios", usuario);
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task EliminarUsuario(string correo)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().DeleteAsync($"/usuarios/correo/{correo}");
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task ActualizarUsuario(Usuario usuario)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/usuarios", usuario);
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task ActualizarContrasena(string correo, string nuevaContrasena)
    {
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PutAsJsonAsync(
            $"/usuarios/{correo}/contrasena",
            new { NuevaContrasena = nuevaContrasena });

            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task ActualizarRolesUsuario(string correo, List<string> roles){
        try
        {
            await checkTokenExpiration();
            var response = await this.mySession.GetClient().PutAsJsonAsync($"/usuarios/{correo}/roles", roles);
            ensureFunctions.ensureGet(response);
        } catch (Exception ex) {
            Log.Error(ex);
            throw;
        }
    }
    public async Task checkTokenExpiration()
    {
        if (this.mySession.getToken() == null){ return; }
        if (tokenHelper.checkRenovateToken(this.mySession.getToken().exp))
        {
            await mySession.GenerateToken();
        }
    }
}
