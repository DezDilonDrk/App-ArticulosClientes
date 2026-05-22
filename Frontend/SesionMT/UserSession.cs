
using Articulos_Frontend.Client;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using SesionMT.LogConfig;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using static MTCore_AC.DTO.LoginDtos;

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

        public UserSession(string currentServer, string token = null)
        {
            this.currentServer = currentServer;
            this.email = email;
            this.password = password;
            if (fileExists())
            {
                this.token = CargarToken();
            }
            if (fileExists() && tokenExpired())
            {
                TokenDto tokenDto = getToken();
                Log.Info($"Token para {tokenDto.correo} ha expirado. Renovando token.");
                if (tokenDto == null)
                {
                    Log.Warn("No se pudo decodificar el token. Eliminando token almacenado.");
                    BorrarToken();
                    this.token = null;
                }
                else
                {
                    this.email = tokenDto.correo;
                    this.password = tokenDto.password;
                    this.token = GenerateToken().GetAwaiter().GetResult();
                    GuardarToken();
                    Log.Info($"Token renovado exitosamente para {tokenDto.correo}.");
                }
            } else if (!string.IsNullOrEmpty(token))
            {
                this.token = token;
                GuardarToken();
            }
            configApi = new ConfiguracionApiClient(this);
            api = new UsuarioApiClient(this);

            this.client = new HttpClient();
            client.BaseAddress = new Uri(currentServer);

            if (!string.IsNullOrEmpty(this.token)){
                this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.token);
            }
        }
        public UserSession(string currentServer)
        {
            this.currentServer = currentServer;
            configApi = new ConfiguracionApiClient(this);
            api = new UsuarioApiClient(this);
            if (fileExists())
            {
                this.token = CargarToken();
            }
            if (fileExists() && tokenExpired())
            {
                TokenDto tokenDto = getToken();
                Log.Info($"Token para {tokenDto.correo} ha expirado. Renovando token.");
                if (tokenDto == null)
                {
                    Log.Warn("No se pudo decodificar el token. Eliminando token almacenado.");
                    BorrarToken();
                    this.token = null;
                }
                else
                {
                    GuardarToken();
                    Log.Info($"Token renovado exitosamente para {tokenDto.correo}.");
                }
            }
            this.client = new HttpClient();
            client.BaseAddress = new Uri(currentServer);
            if (!string.IsNullOrEmpty(this.token))
            {
                this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.token);
            }
        }
        public void Init(string email, string password)
        {
            if (tokenExpired())
            {
                this.email = email;
                this.password = password;
            }
        }
        public void loginUser()
        {
            token = CargarToken();
            roles = getRoles();
            this.email = getEmail();
            _ = ConfigurationSet(email); // Ojo
        }
        private async Task ConfigurationSet(string email)
        {
            await configApi.InitAsync(currentServer);
            var config = await configApi.ObtenerConfiguracionPorCorreo(email);
            if (config == null){
                config = new ConfiguracionModel { SendNotifications = true };
            }
            setConfiguracion(config);
            await configApi.GuardarConfiguracionPorCorreo(email, config);
        }
        public bool tokenExpired()
        {
            /*if (string.IsNullOrEmpty(this.token)) // RECORDAR: Activar de nuevo esta parte y hacer que no ocasione errores
            {
                return true;
            }*/
            TokenDto tokenDto = getToken();
            if (tokenDto == null){
                return true;
            }
            var expString = tokenDto.exp.ToString();
            long exp;
            try
            {
                exp = long.Parse(expString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar la expiración del token: {ex.Message}");
                return true; // Si hay un error, asumime que el token está expirado
            }
            var expDate = DateTimeOffset.FromUnixTimeSeconds(exp);
            return expDate < DateTimeOffset.UtcNow.AddSeconds(300); // Número de segundos de margen. 300 son 5 minutos, por ejemplo
        }
        public string getEmail()
        {
            TokenDto tokenDto = getToken();
            return tokenDto.correo;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getContrasena()
        {
            TokenDto tokenDto = getToken();
            return tokenDto.password;
        }
        public string getNombre()
        {
            TokenDto tokenDto = getToken();
            return tokenDto.nombre;
        }
        public List<string> getRoles()
        {
            TokenDto tokenDto = getToken();
            if (tokenDto == null){ return new List<string>(); }
            return tokenDto.roles;
        }
        public void setRoles()
        {
            roles = getToken().roles;
        }
        public void setToken(string token)
        {
            this.token = token;
            this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            setRoles();
            GuardarToken();
        }
        public void GuardarToken()
        {
            try
            {
                var directory = Path.GetDirectoryName(tokenPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllText(tokenPath, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el token: {ex.Message}");
            }
        }
        public string CargarToken(string token = null, string email = null, string password = null)
        {
            this.email = email;
            this.password = password;
            try
            {
                if (File.Exists(tokenPath))
                {
                    var content = File.ReadAllText(tokenPath);
                    token = content;
                    return token;
                }
                else
                {
                    this.token = GenerateToken().GetAwaiter().GetResult();
                    GuardarToken();
                    return this.token;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el token: {ex.Message}");
            }
            return null;
        }
        public bool fileExists()
        {
            return File.Exists(tokenPath);
        }
        public void BorrarToken()
        {
            try
            {
                if (File.Exists(tokenPath))
                {
                    File.Delete(tokenPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el token: {ex.Message}");
            }
        }
        private async Task<string> GenerateToken()
        {
            var loginData = new
            {
                Email = email,
                Password = password
            };

            var resp = await client.PostAsJsonAsync("/usuarios/login", loginData);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            var doc = JsonSerializer.Deserialize<LoginDtos.LoginResponse>(json);

            token = doc.token;
            return doc.token;
        }
        public HttpClient GetClient()
        {
            if (tokenExpired())
            {
                Init(email, password);
            }
            return this.client;
        }
        public TokenDto getToken()
        {
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
