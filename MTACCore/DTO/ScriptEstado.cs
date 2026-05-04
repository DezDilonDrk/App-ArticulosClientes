using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.DTO
{
    public class ScriptEstado
    {
        public string Nombre { get; set; }
        public bool Ejecutado { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
