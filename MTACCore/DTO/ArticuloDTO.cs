using System;
using System.Collections.Generic;
using System.Text;

namespace MTCore_AC.DTO
{
    public class ArticuloDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public string DisenoCasco { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public ArticuloDTO(String id, String nombre, decimal precio, String categoria, String disenoCasco, DateTime fechaCreacion, DateTime? fechaActualizacion) {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
            DisenoCasco = disenoCasco;
            FechaCreacion = fechaCreacion;
            FechaActualizacion = fechaActualizacion;
        }

        public ArticuloDTO() //como toques este constructor vacío te crujo, 4 horas de pruebas para solucionar un error concluyeron con este maldito constructor vacío.
        {
            
        }
    }
}
