using MTCore_AC.DTO;
using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace SesionMT;

public class TokenHelper
{
    private string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ERP_MT", "sessionToken.txt");
    private string token;
    public TokenHelper()
    {}
    public void setToken(string token)
    {
        this.token = token;
        GuardarToken(token);
    }
    public void GuardarToken(string token)
    {
        var directory = Path.GetDirectoryName(tokenPath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        File.WriteAllText(tokenPath, token);
    }
     public bool tokenExists(){
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
    public bool tokenExpired()
    {
        /*if (string.IsNullOrEmpty(this.token)) // RECORDAR: Activar de nuevo esta parte y hacer que no ocasione errores
        {
            return true;
        }*/
        TokenDto tokenDto = getToken();
        if (tokenDto == null)
        {
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
        var limitDate = DateTimeOffset.UtcNow.AddDays(-30);
        return ((expDate < DateTimeOffset.UtcNow.AddSeconds(300)) || (expDate < limitDate)); // Número de segundos de margen. 300 son 5 minutos, por ejemplo. Además de que no tenga más de 30 días de haber caducado
    }
    public string ObtenerToken()
    {
        try
        {
            if (File.Exists(tokenPath))
            {
                return File.ReadAllText(tokenPath);
            }
            else
            {
                Console.WriteLine("No se encontró el token.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener el token: {ex.Message}");
            return null;
        }
    }
    public TokenDto getToken()
    {
        if (string.IsNullOrEmpty(token)) { 
            token = ObtenerToken();
            if (string.IsNullOrEmpty(token)) {
                return null; 
            }
        }
        TokenDto tokenDto = TokenDto.DecodeJwt(token);
        return tokenDto;
    }
    public string getEmail()
    {
        TokenDto tokenDto = getToken();
        return tokenDto.correo;
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
        if (tokenDto == null) { return new List<string>(); }
        return tokenDto.roles;
    }
    public string getServer()
    {
        TokenDto tokenDto = getToken();
        return tokenDto.server;
    }
    public bool checkRenovateToken(long expToken)
    {
        var expDate = DateTimeOffset.FromUnixTimeSeconds(expToken);
        var limitDate = DateTimeOffset.UtcNow.AddDays(-30);
        return ((expDate < DateTimeOffset.UtcNow.AddSeconds(300)) || (expDate < limitDate));
    }
}
