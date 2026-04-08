using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class Usuario
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }

        public Usuario() { }

        public Usuario(string correo, string nombre, string contrasena, string rol)
        {
            this.Correo = correo;
            this.Nombre = nombre;
            this.Contrasena = contrasena;
            this.Rol = rol;
        }

        public Usuario(string correo, string contrasena)
        {
            this.Correo = correo;
            this.Contrasena = contrasena;
        }

    }
}
