using Articulos_Frontend.Client;
using MTCore_AC.Entidades;
using SesionMT.LogConfig;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SesionMT;

public class ConfiguracionHelper
{
    private ConfiguracionApiClient configuracionApiClient;
    public ConfiguracionHelper(UserSession userSession) {
        configuracionApiClient = new ConfiguracionApiClient(userSession);
    }
    public async Task<ConfiguracionModel> getConfiguracion(string email){
        await configuracionApiClient.InitAsync(UrlMT.serverLocal);
        var config = await configuracionApiClient.ObtenerConfiguracionPorCorreo(email);
        return config;
    }
    public async Task guardarConfiguracion(string email, ConfiguracionModel config) {
        if (config != null)
        {
            try
            {
                configuracionApiClient.GuardarConfiguracionPorCorreo(email, config);

            }
            catch (Exception ex)
            {
                Log.Error("Error al guardar la configuración de notificaciones: " + ex.Message);
                /*Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                alerta.ShowDialog();*/
                return;
            }
        }
        else
        {
            Log.Warn($"No se encontró configuración para el usuario {email}. Se establecerá la configuración predeterminada.");
            config = new ConfiguracionModel { SendNotifications = true };
            try
            {
                configuracionApiClient.GuardarConfiguracionPorCorreo(email, config);

            }
            catch (Exception ex)
            {
                Log.Error("Error al guardar la configuración de notificaciones: " + ex.Message);
                /*Alerta alerta = new Alerta(Alerta.AlertaTipo.Error, ex);
                alerta.ShowDialog();*/
                return;
            }
        }
    }
}
