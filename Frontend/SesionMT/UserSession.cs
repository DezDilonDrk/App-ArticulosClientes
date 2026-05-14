
using MTCore_AC.DTO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using static MTCore_AC.DTO.LoginDtos;

namespace SesionMT
{
    public class UserSession
    {
        HttpClient client;
        string username = "";
        string password = "";
        private string nombre = "";
        public string token = null;
        private string currentServer = "";
        string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ERP_MT", "session.token");

        public UserSession(string currentServer, string token = null)
        {
            this.currentServer = currentServer;
            this.token = CargarToken();
            if (token != null) {
                this.token = token;
            }
        }
        public async Task Init(string username, string password)
        {
            if (tokenExpired()) {
                this.username = username;
                this.password = password;
                this.client = new HttpClient();
                client.BaseAddress = new Uri(currentServer);
                this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
        public bool tokenExpired()
        {
            if (string.IsNullOrEmpty(this.token))
            {
                return true;
            }
            var json = GetPayload();
            var expString = json.Split("\"exp\":")[1].Split(",")[0];
            long exp;
            try {
                exp = long.Parse(expString);
            } catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar la expiración del token: {ex.Message}");
                return true; // Si hay un error, asumime que el token está expirado
            }
            var expDate = DateTimeOffset.FromUnixTimeSeconds(exp);
            return expDate < DateTimeOffset.UtcNow.AddSeconds(300); // Número de segundos de margen. 300 son 5 minutos, por ejemplo
        }
        private string GetPayload()
        {
            var partes = token.Split('.');
            var payload = partes[1];
            payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
            return Encoding.UTF8.GetString(Convert.FromBase64String(payload));
        }
        public string getEmail()
        {
            var json = GetPayload();
            return json.Split("\"name\":\"")[1].Split('"')[0];
        }
        public List<string> getRoles()
        {
            var json = GetPayload();
            var rolesString = json.Split("\"role\":[")[1].Split("]")[0];
            rolesString = rolesString.Replace("\"", "").Replace("[", "").Replace("]", "");
            var roles = rolesString.Split(',').ToList();
            return roles;
        }
        public void GuardarToken() {
            try
            {
                var directory = Path.GetDirectoryName(tokenPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string encodedPassword = Encode(password);
                File.WriteAllText(tokenPath, $"{token}|{username}|{encodedPassword}|{nombre}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el token: {ex.Message}");
            }
        }
        private string Encode(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }

        private string Decode(string encoded)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
        }
        public string CargarToken() {
            try
            {
                if (File.Exists(tokenPath))
                {
                    var content = File.ReadAllText(tokenPath);
                    var parts = content.Split('|');
                    if (parts.Length == 4)
                    {
                        token = parts[0];
                        username = parts[1];
                        password = Decode(parts[2]);
                        nombre = parts[3];
                    }
                    return token;
                } else {
                    GetToken().GetAwaiter().GetResult();
                    return this.token;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el token: {ex.Message}");
            }
            return null;
        }
        public bool tokenExists() {
            return File.Exists(tokenPath);
        }
        public void BorrarToken() {
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
            /*if (!String.IsNullOrEmpty(token))
            {
                return token;
            }*/

            var loginData = new
            {
                Email = username,
                Password = password
            };

            var resp = await client.PostAsJsonAsync("/usuarios/login", loginData);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            var doc = JsonSerializer.Deserialize<LoginDtos.LoginResponse>(json);

            token = doc.token;
            return doc.token;
        }
        public async Task<string> GetToken()
        {
            if (string.IsNullOrEmpty(this.token))
            {
                this.token = await GenerateToken();
                GuardarToken();
            }
            return this.token;
        }
        public string getContrasena()
        {
            return this.password;
        }
        public HttpClient GetClient()
        {
            if (tokenExpired())
            {
                Init(username, password).GetAwaiter().GetResult();
            }
            return this.client;
        }
    }
}
