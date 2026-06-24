
using Articulos_Frontend.Client;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using SesionMT.LogConfig;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using static MTCore_AC.DTO.LoginDtos;
using Articulos_Frontend;

namespace SesionMT
{
    public class UserSession
    {
        HttpClient client;
        private UsuarioApiClient api;
        private ConfiguracionApiClient configApi;
        private string email = "";
        private List<string> roles;
        private string password = "";
        private string token = null;
        private string currentServer = "";
        string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ERP_MT", "sessionToken.txt");

        TokenHelper tokenHelper = new TokenHelper();

        public UserSession(string currentServer, string token = null)
        {
            //currentServer = null;
            this.currentServer = currentServer;
            if (!string.IsNullOrEmpty(currentServer))
            {
                this.currentServer = UrlMT.baseUrl + currentServer.ToUpper();
            }
            /*this.email = email;
            this.password = password;*/
            checkClient();
            if (tokenHelper.tokenExists())
            {
                this.token = CargarToken();
                if (tokenHelper.tokenExpired())
                {
                    TokenDto tokenDto = tokenHelper.getToken();
                    if (tokenDto == null)
                    {
                        Log.Warn("No se pudo decodificar el token. Eliminando token almacenado.");
                        tokenHelper.BorrarToken();
                        this.token = null;
                    }
                    else
                    {
                        Log.Info($"Token para {tokenDto.correo} ha expirado. Renovando token.");
                        this.email = tokenDto.correo;
                        this.password = tokenDto.password;
                        this.token = GenerateToken().GetAwaiter().GetResult();
                        tokenHelper.GuardarToken(this.token);
                        Log.Info($"Token renovado exitosamente para {tokenDto.correo}.");
                    }
                }
                else if (!string.IsNullOrEmpty(token))
                {
                    this.token = token;
                    tokenHelper.GuardarToken(this.token);
                }
            }
            configApi = new ConfiguracionApiClient(this);
            api = new UsuarioApiClient(this);

            this.client = new HttpClient();
            if (!string.IsNullOrEmpty(currentServer)) { 
                if(currentServer.ToUpper().Contains(UrlMT.baseUrl.ToUpper())){ 
                    client.BaseAddress = new Uri(currentServer.ToUpper());  
                } else {
                    client.BaseAddress = new Uri(UrlMT.baseUrl + currentServer.ToUpper());
                }
            }
           
            if (!string.IsNullOrEmpty(this.token))
            {
                this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.token);
            }
            checkClient();
        }
        public UserSession(string currentServer)
        {
            this.currentServer = currentServer;
            configApi = new ConfiguracionApiClient(this);
            api = new UsuarioApiClient(this);
            if (tokenHelper.tokenExists())
            {
                if (tokenHelper.tokenExpired()) { 
                    tokenHelper.BorrarToken(); 
                }
                this.token = tokenHelper.ObtenerToken();
            }
           
            TokenDto tokenDto = tokenHelper.getToken();
            Log.Info($"Token para {tokenDto.correo} ha expirado. Renovando token.");
            if (tokenDto == null)
            {
                Log.Warn("No se pudo decodificar el token. Eliminando token almacenado.");
                tokenHelper.BorrarToken();
                this.token = null;
            }
            else
            {
                tokenHelper.GuardarToken(this.token);
                Log.Info($"Token renovado exitosamente para {tokenDto.correo}.");
            }
            this.client = new HttpClient();
            if(string.IsNullOrEmpty(currentServer))
            {
                currentServer = UrlMT.serverLeandro; // Valor por defecto
            }
            client.BaseAddress = new Uri(UrlMT.baseUrl + currentServer.ToUpper());
            if (!string.IsNullOrEmpty(this.token))
            {
                this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.token);
            }

        }
        public void Init(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        public void loginUser()
        {
            token = CargarToken();
            roles = getRoles();
            this.email = getEmail();
            _ = ConfigurationSet(email); // Ojo
        }
        private void checkClient()
        {
            if (this.client == null)
            {
                client = new HttpClient();
                if (string.IsNullOrEmpty(currentServer)) { return; }
                if (currentServer.ToUpper().Contains(UrlMT.baseUrl.ToUpper())) { 
                    client.BaseAddress = new Uri(currentServer.ToUpper()); 
                } else
                {
                    client.BaseAddress = new Uri(UrlMT.baseUrl + currentServer.ToUpper());
                }
                if (!string.IsNullOrEmpty(this.token))
                {
                    this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.token);
                }
            }
        }
        private async Task ConfigurationSet(string email)
        {
            await configApi.InitAsync(currentServer);
            var config = await configApi.ObtenerConfiguracionPorCorreo(email);
            if (config == null) {
                config = new ConfiguracionModel { SendNotifications = true };
            }
            setConfiguracion(config);

            try
            {
                await configApi.GuardarConfiguracionPorCorreo(email, config);
            }
            catch (Exception ex)
            {
                Log.Error("Error al guardar la configuración del usuario: " + ex.Message);
                throw;
            }
        }
        public string getEmail()
        {
            return tokenHelper.getEmail();
        }
        public string getContrasena()
        {
            return tokenHelper.getContrasena();
        }
        public string getNombre()
        {
            return tokenHelper.getNombre();
        }
        public List<string> getRoles()
        {
            var roles = tokenHelper.getRoles();
            if (roles == null)
            {
                return new List<string>();
            }
            return roles;
        }
        public void setRoles()
        {
            roles = tokenHelper.getRoles();
        }
        public void setToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("El token no puede ser nulo o vacío.");
            }
            tokenHelper.setToken(token);
            this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            setRoles();
            tokenHelper.GuardarToken(token);
        }
        public void setServer(string server)
        {
            this.currentServer = server.ToUpper();
            if (this.client != null)
            {
                if (this.client.BaseAddress == null) { this.client.BaseAddress = new Uri(UrlMT.baseUrl + this.currentServer); }
            } else {
                checkClient(); 
            }
        }
        public string CargarToken(string token = null, string email = null, string password = null)
        {
            this.email = email;
            this.password = password;
            try
            {
                if (tokenHelper.tokenExists())
                {
                    var content = File.ReadAllText(tokenPath);
                    this.token = content;
                    return this.token;
                }
                checkClient();
                this.token = GenerateToken().GetAwaiter().GetResult();
                tokenHelper.GuardarToken(this.token);
                return this.token;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el token: {ex.Message}");
            }
            return null;
        }
        public async Task<string> GenerateToken()
        {
            var loginData = new
            {
                Email = email,
                Password = password
            };
            var resp = await client.PostAsJsonAsync("/usuarios/login", loginData);
            if (!resp.IsSuccessStatusCode)
            {
                tokenHelper.BorrarToken();
            }

            var json = await resp.Content.ReadAsStringAsync();
            var doc = JsonSerializer.Deserialize<LoginDtos.LoginResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            token = doc.token;
            tokenHelper.setToken(token);
            return doc.token;
        }
        public HttpClient GetClient()
        {
            if (tokenHelper.tokenExpired())
            {
                Init(email, password);
            }
            if (this.client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(UrlMT.baseUrl + currentServer.ToUpper());
            }
            return this.client;
        }
        public TokenDto getToken()
        {
            if (string.IsNullOrEmpty(token)) { return tokenHelper.getToken(); }
            TokenDto tokenDto = TokenDto.DecodeJwt(token);
            return tokenDto;
        }
        public static ConfiguracionModel setConfiguracion(ConfiguracionModel config)
        {
            //configuracion = config;
            return config;
        }
        public ConfiguracionApiClient getConfiguracionApiClient()
        {
            return this.configApi;
        }
        public UsuarioApiClient getUsuarioApiClient()
        {
            return this.api;
        }
    }
}
