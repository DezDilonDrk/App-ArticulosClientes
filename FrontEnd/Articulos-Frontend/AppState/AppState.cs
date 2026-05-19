using Articulos_Frontend.Client;
using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Articulos_Frontend;

public static class AppState
{

    private static UserSession UserSession;
    private static ConfiguracionModel configuracion;
    public static string serverLeandro = UrlMT.serverLeandro;
    public static string serverEmilio = UrlMT.serverEmilio;
    public static ConfiguracionModel getConfiguracion()
    {
        if (configuracion == null)
        {
            ConfiguracionApiClient apiConfiguracion = new ConfiguracionApiClient();
            apiConfiguracion.InitAsync(getServer()).Wait();
            apiConfiguracion.ObtenerConfiguracionPorCorreo(UserSession.getEmail()).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    configuracion = task.Result;
                }
                else
                {
                    Log.Error("Error al obtener la configuración: " + task.Exception?.Message);
                    configuracion = new ConfiguracionModel { SendNotifications = true };
                }
            }).Wait();
            Log.Warn("La configuración es nula. Se devolverá una configuración predeterminada.");
        }
        return configuracion;
    }
    public static void initSession()
    {
        UserSession = new UserSession(getServer(), "");
    }
    public static UserSession getUserSession()
    {
        if (UserSession == null) {initSession();}
        return UserSession;
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
