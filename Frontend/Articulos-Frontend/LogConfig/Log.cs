using NLog;
namespace Articulos_Frontend.LogConfig
{
    internal class Log
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message) => logger.Info(message);
        public static void Warn(string message) => logger.Warn(message);
        public static void Error(string message, Exception ex) => logger.Error(message);

        public static void Error(Exception ex, string message = null)
        {
            if (message == null)
                logger.Error(ex);
            else
                logger.Error(ex, message);
        }

        internal static void Error(string v)
        {
            throw new NotImplementedException();
        }
    }
}
