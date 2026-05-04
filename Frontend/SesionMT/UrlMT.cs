using System;
using System.Collections.Generic;
using System.Text;

namespace SesionMT
{
    public static class UrlMT
    {
        private static string serverLeandro = "http://PT-0057:5000";
        private static string serverEmilio = "http://PT-0041:5000";
        private static string serverlocal = "http://localhost:5000";
        public static string getUrl(string? tipo)
        {
            switch (tipo)
            {
                case "leandro":
                    return serverLeandro;
                case "emilio":
                    return serverEmilio;
                case "local":
                    return serverlocal;
                default:
                    return serverlocal;
            }
        }
    }
}
