using Microsoft.VisualBasic.Logging;
using NLog;
namespace Articulos_Frontend.LogConfig
{
    internal class Log
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static List<string> logHistory = new List<string>();
        private static void addLog(string log){
            logHistory.Add(log);
            if (logHistory.Count > 500) {
                logHistory.RemoveAt(0);
            }
        }
        public static List<string> GetLogHistory() {
            return logHistory;
        }
        public static void Info(string message)
        {
            var log = $"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            logger.Info(message);
            OnLog?.Invoke(log);
            addLog(log);
        }
        public static void Debug(string message)
        {
            var log = $"[DEBUG] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            logger.Debug(message);
            OnLog?.Invoke(log);
            addLog(log);
        }
        public static void Warn(string message)
        {
            var log = $"[WARN] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            logger.Warn(message);
            OnLog?.Invoke(log);
            addLog(log);
        }
        public static void Error(string message, Exception ex)
        {
            var log = $"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            logger.Error(message);
            OnLog?.Invoke(log);
            addLog(log);
        }
        public static Action<string> OnLog;
        public static void Error(Exception ex, string message = null)
        {
            var log = $"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            if (message == null) {
                logger.Error(ex);
                OnLog?.Invoke(log);
                addLog(log);
            }
            else {
                logger.Error(ex, message);
                OnLog?.Invoke(log);
                addLog(log);
            }
        }
        internal static void Error(string message = null)
        {
            var log = $"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            if (message == null) {
                logger.Error(message);
                OnLog?.Invoke(log);
                addLog(log);
            }
            else {
                logger.Error("Error desconocido");
                OnLog?.Invoke(log);
                addLog(log);
            }
        }
    }
}
