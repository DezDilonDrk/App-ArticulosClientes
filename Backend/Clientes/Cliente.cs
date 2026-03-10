using System.ComponentModel.DataAnnotations;

namespace ClientesASPNET;

public class Cliente
{
    public string Dni { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; } = DateTime.Now;
    public Cliente() { }

    public Cliente(string dni, string nombre, string apellidos, string email, DateTime) {
        this.Dni = dni;
        this.Nombre = nombre;
        this.Apellidos = apellidos;
        this.Email = email;
    }
}
