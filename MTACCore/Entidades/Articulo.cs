using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.Entidades;

public class Articulo
{
    public String id { get; set; }
    public String Nombre { get; set; }
    public decimal Precio { get; set; }

    public String Categoria { get; set; }

    public String? IdDisenoCasco { get; set; }

    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaActualizacion { get; set; }

    public Articulo(String id, String nombre, decimal precio, String categoria, String? idDisenoCasco, DateTime fechaCreacion, DateTime? fechaActualizacion)
    {
        this.id = id;
        this.Nombre = nombre;
        this.Precio = precio;
        this.Categoria = categoria;
        this.IdDisenoCasco = idDisenoCasco;
        this.FechaCreacion = fechaCreacion;
        this.FechaActualizacion = fechaActualizacion;
    }
    public Articulo(Guid id, String nombre, decimal precio, String categoria, String? idDisenoCasco, DateTime fechaCreacion, DateTime? fechaActualizacion)
    {
        this.id = id.ToString();
        this.Nombre = nombre;
        this.Precio = precio;
        this.Categoria = categoria;
        this.IdDisenoCasco = idDisenoCasco;
        this.FechaCreacion = fechaCreacion;
        this.FechaActualizacion = fechaActualizacion;
    }

    public Articulo()
    {
    }
}
