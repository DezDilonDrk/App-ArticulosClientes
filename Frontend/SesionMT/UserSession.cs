
using MTCore_AC.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace SesionMT
{
    public static class UserSession
    {
        public static string token = "";
        //Sustituir lo del front por esto, para usarlo aquí y en Test
        public static async Task<string> GenerateToken()
        {
            if (!String.IsNullOrEmpty(token))
            {
                return token;
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri(UrlMT.getUrl("local"));

            var loginData = new
            {
                Email = "leandro.santilario@mthelmets.com",
                Password = "Leandro321"
            };

            var resp = await client.PostAsJsonAsync("/usuarios/login", loginData);
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            var doc = JsonSerializer.Deserialize<LoginDtos.LoginResponse>(json);

            token = doc.token;
            return doc.token;
        }
    }
}
