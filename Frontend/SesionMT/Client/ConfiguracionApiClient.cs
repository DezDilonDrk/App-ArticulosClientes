using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Articulos_Frontend.Client
{
    public class ConfiguracionApiClient
    {
        TokenHelper tokenHelper = new TokenHelper();
        UserSession mySession;
        private EnsureFunctions ensureFunctions = new EnsureFunctions();
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
                await checkTokenExpiration();
                try { 
                    var response = await this.mySession.GetClient().GetAsync($"/configuracion/{correo}");
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                    ensureFunctions.ensureGet(response);
                } catch (HttpRequestException ex) {
                    Log.Error(ex);
                    tokenHelper.BorrarToken();
                    throw;
                }
                return await this.mySession.GetClient().GetFromJsonAsync<ConfiguracionModel>($"/configuracion/{correo}");
            } catch (Exception ex) {
                Log.Error(ex);
                throw;
            }
        }
        public async Task<ConfiguracionModel> GuardarConfiguracionPorCorreo(string correo, ConfiguracionModel configuracion)
        {
            try
            {
                await checkTokenExpiration();
                var response = await this.mySession.GetClient().PostAsJsonAsync($"/guardar_configuracion/{correo}", configuracion);
                response.EnsureSuccessStatusCode();
                ensureFunctions.ensureGet(response);
                return await response.Content.ReadFromJsonAsync<ConfiguracionModel>();
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
}
