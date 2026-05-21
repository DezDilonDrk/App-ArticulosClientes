using MTCore_AC.Entidades;
using SesionMT;
using SesionMT.LogConfig;
using System.Reflection;

namespace Articulos_Frontend;

internal static class Program
{

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Log.Info("---- Iniciando aplicación con versión: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        UserSession userSession = new UserSession(UrlMT.serverLocal);
        AppState.setUserSession(userSession);
        if (userSession.fileExists())
        {
            var form = new Menu(AppState.getUserSession().getUsuarioApiClient(), new Usuario(userSession.getEmail(), userSession.getNombre(), userSession.getContrasena()));
            userSession.loginUser();
            Application.Run(form);
        } else
        {
            Application.Run(new LoginForm());
        }
        Log.Info("---- Aplicación finalizada");
    }
}