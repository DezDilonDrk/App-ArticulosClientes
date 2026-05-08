
using MTCore_AC.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace SesionMT
{
    public class UserSession
    {
        HttpClient client;
        string username = "";
        string password = "";
        public string token = null;
        private string currentServer = "";

        public UserSession(string currentServer )
        {
            this.currentServer = currentServer;
        }
        public async Task Init(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.client = new HttpClient();
            token = await GenerateToken();
            this.client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }

        //Sustituir lo del front por esto, para usarlo aquí y en Test
        private async Task<string> GenerateToken()
        {
            /*if (!String.IsNullOrEmpty(token))
            {
                return token;
            }*/
            client.BaseAddress = new Uri(currentServer);

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

        public HttpClient GetClient()
        {
            return this.client;
        }
    }
}
