using System;
using System.ComponentModel.DataAnnotations;

namespace ClientesASPNET;

public class Cliente
{
    public string Dni { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }

    public Cliente() {}

    public Cliente(string dni, string nombre, string apellidos, string email, DateTime FechaCreacion, DateTime? FechaModificacion) {
        this.Dni = dni;
        this.Nombre = nombre;
        this.Apellidos = apellidos;
        this.Email = email;
        this.FechaCreacion = FechaCreacion;
        this.FechaModificacion = FechaModificacion;
    }
}
