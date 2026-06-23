using SesionMT.LogConfig;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SesionMT
{
    public class EnsureFunctions
    {

        public void ensureGet(HttpResponseMessage response, [CallerMemberName] string methodName = "")
        {
            if (!response.IsSuccessStatusCode)
            {
                Log.Error($"Error en {methodName}: {response.Content}");
               // throw new Exception($"Error con {methodName}: {response.StatusCode}");
            }
        }
    }
}
