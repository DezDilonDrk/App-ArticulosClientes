using MTCore_AC.Entidades;

namespace MTCore_AC.DTO;

public class LoginDtos
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public Usuario Usuario { get; set; }
    }
}
