using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend
{
    public class FormMT
    {
        public Form formularioHijo { get; set; }
        public Form formularioPadre { get; set; }
         public FormMT(Form formularioPadre, Form formularioHijo)
        {
            this.formularioPadre = formularioPadre;
            this.formularioHijo = formularioHijo;
        }
    }
}
