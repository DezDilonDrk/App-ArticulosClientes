using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class DisenoCasco
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public DisenoCasco(string nombre, string descripcion)
        {
            this.id = Guid.NewGuid().ToString();
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public DisenoCasco()
        {
            
        }
    }
}
