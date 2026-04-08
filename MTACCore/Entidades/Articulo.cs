using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades;

public class Articulo
{
    public int id { get; set; }

    //[Required(ErrorMessage = "Nombre obligatorio")]
    //[StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
    public String nombre { get; set; }
    public decimal precio { get; set; }

    public String categoria { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }

    public Articulo(int id, String nombre, decimal precio, String categoria, DateTime fechaCreacion, DateTime? fechaActualizacion)
    {
        this.id = id;
        this.nombre = nombre;
        this.precio = precio;
        this.categoria = categoria;
        this.FechaCreacion = fechaCreacion;
        this.FechaActualizacion = fechaActualizacion;
    }
    public Articulo(String nombre, decimal precio, String categoria, DateTime fechaCreacion, DateTime? fechaActualizacion)
    {
        this.nombre = nombre;
        this.precio = precio;
        this.categoria = categoria;
        this.FechaCreacion = fechaCreacion;
        this.FechaActualizacion = fechaActualizacion;
    }

    public Articulo()
    {
    }
}
