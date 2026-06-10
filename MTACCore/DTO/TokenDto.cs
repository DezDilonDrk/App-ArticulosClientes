using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MTCore_AC.DTO;

public class TokenDto
{
    public string correo { get; set; }
    public List<string> roles { get; set; }
    public string nombre { get; set; }
    public string password { get; set; }
    public long exp { get; set; }
    public string server { get; set; }

    [JsonPropertyName("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")]
    public string claimName { get; set; }

    public static TokenDto DecodeJwt(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("El token es nulo o vacío.");
            return null;
        }
        string[] parts = token.Split('.');
        try
        {
            string payload = parts[1];

            int padding = payload.Length % 4;
            if (padding != 0) { payload += new string('=', 4 - padding); }

            payload = payload.Replace('-', '+').Replace('_', '/');
            byte[] bytes = Convert.FromBase64String(payload);
            string json = Encoding.UTF8.GetString(bytes);

            return JsonSerializer.Deserialize<TokenDto>(json);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
