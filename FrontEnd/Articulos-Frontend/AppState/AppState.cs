using MTCore_AC.Entidades;
using SesionMT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Articulos_Frontend;

public static class AppState
{

    public static string Token { get; set; } = string.Empty;
    public static List<string> Roles { get; set; } = new List<string>();
    public static string correo_usuario;
    private static ConfiguracionModel configuracion;
    public static string serverLeandro = UrlMT.serverLeandro;
    public static string serverEmilio = UrlMT.serverEmilio;
    public static string getCorreo()
    {
        return correo_usuario;
    }
    public static string getToken(){
        return Token;
    }
    public static ConfiguracionModel getConfiguracion()
    {
        return configuracion;
    }
    public static void setCorreo(string correo)
    {
        correo_usuario = correo;
    }
    public static void setConfiguracion(ConfiguracionModel config)
    {
        configuracion = config;
    }
    public static void changeCheckNotifications()
    {
        configuracion.SendNotifications = !configuracion.SendNotifications;
    }
    public static string getServer()
    {
        return serverLeandro;
    }
}
