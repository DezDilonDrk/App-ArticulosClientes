using MTCore_AC.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Articulos_Frontend;

public static class AppState
{

    public static string Token { get; set; } = string.Empty;
    public static List<string> Roles { get; set; } = new List<string>();
    private static string correo_usuario;
    private static ConfiguracionModel configuracion;
    public static string getCorreo()
    {
        return correo_usuario;
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
}
