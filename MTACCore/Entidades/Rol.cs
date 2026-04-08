using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades;

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public List<UsuarioRol> UsuarioRoles { get; set; }

    public Rol() { }

    public Rol(int id, string nombre)
    {
        this.Id = id;
        this.Nombre = nombre;
    }
}
