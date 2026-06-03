using MTCore_AC.Entidades;
using System.Text.Json.Serialization;

namespace MTCore_AC.DTO;

public class LoginDtos
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
    }
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        public string token { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public Usuario Usuario { get; set; }
    }
}
