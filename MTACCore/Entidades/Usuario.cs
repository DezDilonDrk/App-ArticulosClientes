using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades
{
    public class Usuario
    {
        public string CorreoElectronico { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }

        public List<UsuarioRol> UsuarioRoles { get; set; }

        public Usuario() { }

        public Usuario(string correoElectronico, string nombre, string contrasena)
        {
            this.CorreoElectronico = correoElectronico;
            this.Nombre = nombre;
            this.Contrasena = contrasena;
        }

        public Usuario(string correoElectronico, string contrasena)
        {
            this.CorreoElectronico = correoElectronico;
            this.Contrasena = contrasena;
        }

    }
}
