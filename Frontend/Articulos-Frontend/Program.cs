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
        ApplicationConfiguration.Initialize();
        Log.Info("---- Iniciando aplicación con versión: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        Application.ThreadException += (s, e) =>
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        };
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            var ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex?.Message ?? "Error desconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        };
        if (AppState.tokenHelper.tokenExists())
        {
            UserSession userSession = AppState.getUserSession();
            AppState.setTokenServer();
            var form = new Menu(AppState.getUserSession().getUsuarioApiClient(), new Usuario(userSession.getEmail(), userSession.getNombre(), userSession.getContrasena()));
            userSession.loginUser();
            Application.Run(form);
        } else {
            Application.Run(new LoginForm());
        }
        Log.Info("---- Aplicación finalizada");
    }
}