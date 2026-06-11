using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System.Net.Http.Json;

namespace Articulos_Frontend.Client
{
    public class ConfiguracionApiClient
    {
        UserSession mySession;
        public ConfiguracionApiClient(UserSession session){
            this.mySession = session;
        }
        public ConfiguracionApiClient(){}
        /*public UserSession GetSession()
        {
            return this.mySession;
        }*/
        public async Task InitAsync(string currentServer)
        {
            /*this.mySession = new UserSession(currentServer);
            mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");
            mySession.CargarToken();*/
        }
        public async Task<ConfiguracionModel> ObtenerConfiguracionPorCorreo(string correo)
        {
            try
            {
                var response = await this.mySession.GetClient().GetAsync($"/configuracion/{correo}");
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                return await this.mySession.GetClient().GetFromJsonAsync<ConfiguracionModel>($"/configuracion/{correo}");
            } catch (Exception ex) {
                Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
                throw;
            }
        }
        public async Task<ConfiguracionModel> GuardarConfiguracionPorCorreo(string correo, ConfiguracionModel configuracion)
        {
            try
            {
                var response = await this.mySession.GetClient().PostAsJsonAsync($"/guardar_configuracion/{correo}", configuracion);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ConfiguracionModel>();
            } catch (Exception ex) {
                Log.Error($"No se pudo conectar al servidor API. Error: {ex.Message}", ex);
                throw;
            }
        }
    }
}
