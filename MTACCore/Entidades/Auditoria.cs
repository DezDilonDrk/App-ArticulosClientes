using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class Auditoria
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Accion { get; set; }
        public string Entidad { get; set; }
        public string? EntidadId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Datos { get; set; }
    }
}
