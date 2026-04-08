using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades;

public class UsuarioRol
{
    public int RolId { get; set; }
    public string UsuarioEmail { get; set; }

    public UsuarioRol() { }

    public UsuarioRol(int rolId, string usuarioEmail)
    {
        this.RolId = rolId;
        this.UsuarioEmail = usuarioEmail;
    }
}
