
using Articulos_Frontend.Client;
using MTCore_AC.DTO;
using MTCore_AC.Entidades;
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
        private UsuarioApiClient api = new UsuarioApiClient();
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
            if (fileExists() && tokenExpired())
            {
                BorrarToken();
                this.token = null;
            } else if (!fileExists() && !string.IsNullOrEmpty(token))
            {
                this.token = token;
                GuardarToken();
            } else if (fileExists())
            {
                this.token = CargarToken();
            }
            configApi = new ConfiguracionApiClient(this);

            this.client = new HttpClient();
            client.BaseAddress = new Uri(currentServer);

            if (token != null){
                this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
        public UserSession(string currentServer)
        {
            this.currentServer = currentServer;
            this.token = CargarToken();
            configApi = new ConfiguracionApiClient(this);
            if (fileExists() && tokenExpired())
            {
                BorrarToken();
                this.token = null;
            }
            this.client = new HttpClient();
            client.BaseAddress = new Uri(currentServer);
            if (token != null) { 
                this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token); 
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
        public string getToken()
        {
            return this.token;
        }
        public bool tokenExpired()
        {
            /*if (string.IsNullOrEmpty(this.token)) // RECORDAR: Activar de nuevo esta parte y hacer que no ocasione errores
            {
                return true;
            }*/
            var json = GetPayload();
            if (json == null){
                return true;
            }
            var expString = json.Split("\"exp\":")[1].Split(",")[0];
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
        private string GetPayload()
        {
            if (string.IsNullOrEmpty(token)){return null;}
            var partes = token.Split('.');
            var payload = partes[1];
            payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
            return Encoding.UTF8.GetString(Convert.FromBase64String(payload));
        }
        public string getEmail()
        {
            var json = GetPayload();
            return json.Split("\"email\":\"")[1].Split('"')[0];
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getContrasena()
        {
            var json = GetPayload();
            return json.Split("\"password\":\"")[1].Split('"')[0];
        }
        public string getNombre()
        {
            var json = GetPayload();
            return json.Split("\"nombre\":\"")[1].Split('"')[0];
        }
        public List<string> getRoles()
        {
            var json = GetPayload();
            int idx = json.IndexOf("\"roles\":");
            if (idx == -1)
                return new List<string>();
            string sub = json.Substring(idx);
            if (sub.Contains("["))
            {
                string arrayPart = sub.Split('[', 2)[1].Split(']', 2)[0];
                return arrayPart
                    .Replace("\"", "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(r => r.Trim())
                    .ToList();
            }
            if (sub.Contains(":"))
            {
                string value = sub.Split(':', 2)[1]
                                  .Split(',', 2)[0]
                                  .Replace("\"", "")
                                  .Trim();

                return new List<string> { value };
            }

            return new List<string>();
        }
        public void setRoles(List<string> roles)
        {
            this.roles = roles;
        }
        public void setToken(string token)
        {
            this.token = token;
            this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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
            this.token = token;
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
