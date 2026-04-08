using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Articulos_Frontend
{
    public static class AppState
    {
        public static string Token { get; set; } = string.Empty;
        public static List<string> Roles { get; set; } = new List<string>();
    }
}
