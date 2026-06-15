using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MTCore_AC.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Articulos_Backend.JWT;

public class JwtService
{
    private readonly string _secretKey = "CLAVE_SECRETA_SECRETOSA_PORFAVOR_FUNCIONA_SOCORRO";


    public string GenerateToken(string correo, List<string> roles, Usuario usuario, string currentServer)
    {
        var claims = new List<Claim>();

        foreach(var role in roles)
        {
            claims.Add(new Claim("roles", role));
        }
        claims.Add(new Claim(ClaimTypes.Name, correo));
        claims.Add(new Claim("correo", correo));
        claims.Add(new Claim("nombre", usuario.Nombre));
        claims.Add(new Claim("password", usuario.Contrasena));
        claims.Add(new Claim("server", currentServer.ToUpper()));
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
