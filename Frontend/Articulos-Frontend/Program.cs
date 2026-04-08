using Articulos_Frontend.LogConfig;
using System.Reflection;

namespace Articulos_Frontend
{
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
            Application.Run(new LoginForm());
            Log.Info("---- Aplicación finalizada");
        }
    }
}